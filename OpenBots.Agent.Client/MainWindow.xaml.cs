﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenBots.Agent.Client.Utilities;
using OpenBots.Agent.Core.Model;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Drawing = System.Drawing;
using Forms = System.Windows.Forms;

namespace OpenBots.Agent.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServerConnectionSettings _connectionSettings;
        private OpenBotsSettings _agentSettings;
        private Timer _serviceHeartBeat;

        private Forms.NotifyIcon _notifyIcon = null;
        private Dictionary<string, Drawing.Icon> _iconHandles = null;
        private Forms.ContextMenu _contextMenuTrayIcon;
        private Forms.MenuItem _menuItemExit;

        private bool _isServiceUP = false;
        private bool _windowHeightReduced = false;
        private bool _logInfoChanged = false;

        public MainWindow()
        {
            InitializeComponent();

            // Connect to WCF Service Endpoint
            _isServiceUP = PipeProxy.Instance.StartServiceEndPoint();
        }

        #region Window Events / Helper Methods
        private void OnInitialized(object sender, EventArgs e)
        {
            _contextMenuTrayIcon = new Forms.ContextMenu();
            _menuItemExit = new Forms.MenuItem();

            // Initialize contextMenu1
            _contextMenuTrayIcon.MenuItems.AddRange(
                        new Forms.MenuItem[] { _menuItemExit });

            // Initialize menuItem1
            _menuItemExit.Index = 0;
            _menuItemExit.Text = "Exit";
            _menuItemExit.Click += menuItemExit_Click;

            _iconHandles = new Dictionary<string, Drawing.Icon>();
            _iconHandles.Add("QuickLaunch", new Drawing.Icon(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OpenBots.ico")));
            _notifyIcon = new Forms.NotifyIcon();
            _notifyIcon.ContextMenu = _contextMenuTrayIcon;
            _notifyIcon.Click += notifyIcon_Click;
            _notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            _notifyIcon.Icon = _iconHandles["QuickLaunch"];
            StateChanged += OnStateChanged;
            Closing += OnClosing;
            Closed += OnClosed;
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            LoadConnectionSettings();
            UpdateConnectButtonState();
            UpdateSaveButtonState();
            StartServiceHeartBeatTimer();

            this.WindowState = WindowState.Minimized;
        }
        private void OnUnload(object sender, RoutedEventArgs e)
        {

        }
        //private void OnFocusOut(object sender, EventArgs e)
        //{
        //    //if (this.WindowState != WindowState.Minimized)
        //    //    this.WindowState = WindowState.Minimized;
        //}
        private void OnStateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Topmost = false;
                this.ShowInTaskbar = false;
                _notifyIcon.Visible = true;
            }
            else
            {
                _notifyIcon.Visible = true;
                this.ShowInTaskbar = true;
                this.Topmost = true;
            }
        }
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                e.Cancel = true;
                this.WindowState = WindowState.Minimized;
            }
        }
        private void OnClosed(object sender, System.EventArgs e)
        {
            try
            {
                if (_notifyIcon != null)
                {
                    _notifyIcon.Visible = false;
                    _notifyIcon.Dispose();
                    _notifyIcon = null;
                }
            }
            catch (Exception)
            {
            }
        }
        private void LoadConnectionSettings()
        {
            _agentSettings = SettingsManager.ReadSettings();
            bool isServerAlive = false;

            // If Server Connection is already Up and Agent has just started.
            if (!string.IsNullOrEmpty(_agentSettings.AgentId) && PipeProxy.Instance.IsServerConnectionUp())
            {
                // Retrieve Connection Settings from Server
                _connectionSettings = PipeProxy.Instance.GetConnectionHistory();
                isServerAlive = true;
            }

            if (_connectionSettings == null)
            {
                _connectionSettings = new ServerConnectionSettings()
                {
                    ServerConnectionEnabled = false,
                    ServerURL = string.Empty,
                    SinkType = string.IsNullOrEmpty(_agentSettings.SinkType) ? Enums.SinkType.File.ToString() : _agentSettings.SinkType,
                    TracingLevel = string.IsNullOrEmpty(_agentSettings.TracingLevel) ? LogEventLevel.Information.ToString() : _agentSettings.TracingLevel,
                    DNSHost = Dns.GetHostName(),
                    MachineName = Environment.MachineName,
                    AgentId = string.Empty,
                    MACAddress = AgentHelper.GetMacAddress(),
                };
            }

            // Loading settings in UI
            txt_MachineName.Text = _connectionSettings.MachineName;
            txt_ServerURL.Text = _connectionSettings.ServerURL;
            txt_AgentId.Text = _connectionSettings.AgentId;
            cmb_LogLevel.ItemsSource = Enum.GetValues(typeof(LogEventLevel));
            cmb_LogLevel.SelectedIndex = Array.IndexOf((Array)cmb_LogLevel.ItemsSource, Enum.Parse(typeof(LogEventLevel), _connectionSettings.TracingLevel));
            cmb_SinkType.ItemsSource = Enum.GetValues(typeof(Enums.SinkType));
            cmb_SinkType.SelectedIndex = Array.IndexOf((Array)cmb_SinkType.ItemsSource, Enum.Parse(typeof(Enums.SinkType), _connectionSettings.SinkType));
            OnSinkSelectionChange();

            if (isServerAlive)
            {
                UpdateUIOnConnect();
            }
        }

        #endregion

        #region Service HeartBeat Method(s)
        private void StartServiceHeartBeatTimer()
        {
            _serviceHeartBeat = new Timer();
            _serviceHeartBeat.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            _serviceHeartBeat.Interval = 10000; //number in miliseconds  
            _serviceHeartBeat.Enabled = true;
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    if (_isServiceUP = PipeProxy.Instance.IsServiceAlive())
                    {
                        if (PipeProxy.Instance.IsServerConnectionUp())
                        {
                            UpdateUIOnConnect();
                        }
                        else
                        {
                            UpdateUIOnDisconnect();
                        }
                    }
                }
                catch (Exception)
                {
                    _isServiceUP = PipeProxy.Instance.StartServiceEndPoint();
                }
                finally
                {
                    if (!_isServiceUP)
                    {
                        UpdateUIOnServiceUnavailable();
                    }
                }
                UpdateConnectButtonState();
            });
        }
        private void UpdateUIOnServiceUnavailable()
        {
            btn_Connect.Content = "Connect";
            lbl_StatusValue.Content = "Not Connected";
            lbl_StatusValue.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF31818"));
            lbl_StatusValue.FontWeight = FontWeights.Bold;
        }

        #endregion

        #region TrayIcon Events / Helper Methods
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            this.Show();
        }
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
        }
        private void menuItemExit_Click(object Sender, EventArgs e)
        {
            // Close the application.
            ExitApplication();
        }
        private void ExitApplication()
        {
            if (_menuItemExit != null)
                _menuItemExit.Dispose();

            if (_contextMenuTrayIcon != null)
                _contextMenuTrayIcon.Dispose();

            Application.Current.Shutdown();
        }

        #endregion

        #region Input Control Events / Helper Methods
        private void OnTextChange_ServerURL(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateConnectButtonState();
        }
        private void OnClick_ConnectBtn(object sender, RoutedEventArgs e)
        {
            if (btn_Connect.Content.ToString() == "Connect")
            {
                // Server Configuration
                _connectionSettings.ServerURL = txt_ServerURL.Text;

                // Logging
                _connectionSettings.TracingLevel = cmb_LogLevel.Text;
                _connectionSettings.SinkType = cmb_SinkType.Text;
                _connectionSettings.LoggingValue1 = txt_SinkType_Logging1.Text;
                _connectionSettings.LoggingValue2 = txt_SinkType_Logging2.Text;
                _connectionSettings.LoggingValue3 = txt_SinkType_Logging3.Text;
                _connectionSettings.LoggingValue4 = txt_SinkType_Logging4.Text;

                var serverResponse = PipeProxy.Instance.ConnectToServer(_connectionSettings);
                if (serverResponse.Data != null)
                {
                    _agentSettings.OpenBotsServerUrl = _connectionSettings.ServerURL;
                    _agentSettings.AgentId = serverResponse.Data.ToString();

                    UpdateUIOnConnect();

                    // Update OpenBots.settings file
                    SettingsManager.UpdateSettings(_agentSettings);
                }
                else
                {
                    ErrorDialog errorDialog = new ErrorDialog("An error occurred while connecting to the server.", 
                        serverResponse.StatusCode, 
                        serverResponse.Message);
                    errorDialog.Owner = Application.Current.MainWindow;
                    errorDialog.ShowDialog();
                }
            }
            else if (btn_Connect.Content.ToString() == "Disconnect")
            {
                var serverResponse = PipeProxy.Instance.DisconnectFromServer(_connectionSettings);
                if (serverResponse.StatusCode == "200")
                {
                    _agentSettings.OpenBotsServerUrl = "";
                    _agentSettings.AgentId = string.Empty;

                    UpdateUIOnDisconnect();

                    // Update OpenBots.settings file
                    SettingsManager.UpdateSettings(_agentSettings);
                }
                else
                {
                    string errorMessage = JToken.Parse(serverResponse.Message).ToString(Formatting.Indented);
                    ErrorDialog errorDialog = new ErrorDialog("An error occurred while disconnecting from the server.",
                        serverResponse.StatusCode,
                        errorMessage);
                    errorDialog.Owner = Application.Current.MainWindow;
                    errorDialog.ShowDialog();
                }

            }
        }
        private void OnDropDownClosed_LogLevel(object sender, EventArgs e)
        {
            if (!_agentSettings.TracingLevel.Equals(cmb_LogLevel.Text) || !_agentSettings.SinkType.Equals(cmb_SinkType.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnDropDownClosed_SinkType(object sender, EventArgs e)
        {
            // Update UI OnSinkSelectionChange
            OnSinkSelectionChange();

            if (!_agentSettings.SinkType.Equals(cmb_SinkType.Text) || !_agentSettings.TracingLevel.Equals(cmb_LogLevel.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnTextChange_Logging1(object sender, TextChangedEventArgs e)
        {
            if (/*(agentSettings.SinkType.Equals("File")|| agentSettings.SinkType.Equals("Http")) && */!_agentSettings.LoggingValue1.Equals(txt_SinkType_Logging1.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnTextChange_Logging2(object sender, TextChangedEventArgs e)
        {
            if (!_agentSettings.LoggingValue2.Equals(txt_SinkType_Logging2.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnTextChange_Logging3(object sender, TextChangedEventArgs e)
        {
            if (!_agentSettings.LoggingValue3.Equals(txt_SinkType_Logging3.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnTextChange_Logging4(object sender, TextChangedEventArgs e)
        {
            if (!_agentSettings.LoggingValue4.Equals(txt_SinkType_Logging4.Text))
                _logInfoChanged = true;
            else
                _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void OnClick_SaveBtn(object sender, RoutedEventArgs e)
        {
            _agentSettings.TracingLevel = cmb_LogLevel.Text;
            _agentSettings.SinkType = cmb_SinkType.Text;
            _agentSettings.LoggingValue1 = txt_SinkType_Logging1.Text;
            _agentSettings.LoggingValue2 = txt_SinkType_Logging2.Text;
            _agentSettings.LoggingValue3 = txt_SinkType_Logging3.Text;
            _agentSettings.LoggingValue4 = txt_SinkType_Logging4.Text;

            SettingsManager.UpdateSettings(_agentSettings);
            _logInfoChanged = false;
            UpdateSaveButtonState();
        }
        private void UpdateUIOnConnect()
        {
            btn_Connect.Content = "Disconnect";
            lbl_StatusValue.Content = "Connected";
            lbl_StatusValue.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4FE823"));
            lbl_StatusValue.FontWeight = FontWeights.Bold;

            // Update Agent Id
            txt_AgentId.Text = _agentSettings.AgentId;

            // Disable Input Controls
            txt_ServerURL.IsEnabled = false;

            cmb_LogLevel.IsEnabled = false;
            cmb_SinkType.IsEnabled = false;
            txt_SinkType_Logging1.IsEnabled = false;
            txt_SinkType_Logging2.IsEnabled = false;
            txt_SinkType_Logging3.IsEnabled = false;
            txt_SinkType_Logging4.IsEnabled = false;
        }
        private void UpdateUIOnDisconnect()
        {
            btn_Connect.Content = "Connect";
            lbl_StatusValue.Content = "Offline";
            lbl_StatusValue.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBBB5B5"));
            lbl_StatusValue.FontWeight = FontWeights.Normal;

            // Update Agent Id
            txt_AgentId.Text = _agentSettings.AgentId;

            // Enable Input Controls
            txt_ServerURL.IsEnabled = true;

            cmb_LogLevel.IsEnabled = true;
            cmb_SinkType.IsEnabled = true;
            txt_SinkType_Logging1.IsEnabled = true;
            txt_SinkType_Logging2.IsEnabled = true;
            txt_SinkType_Logging3.IsEnabled = true;
            txt_SinkType_Logging4.IsEnabled = true;
        }
        private void UpdateConnectButtonState()
        {
            if (lbl_StatusValue.Content.ToString() != "Not Connected" && !string.IsNullOrEmpty(txt_ServerURL.Text) && !btn_Save.IsEnabled)
                btn_Connect.IsEnabled = true;
            else
                btn_Connect.IsEnabled = false;
        }
        private void UpdateSaveButtonState()
        {
            if (_logInfoChanged && _agentSettings.SinkType.Equals("File") && !string.IsNullOrEmpty(txt_SinkType_Logging1.Text))
                btn_Save.IsEnabled = true;
            else if (_logInfoChanged && _agentSettings.SinkType.Equals("Http") && !string.IsNullOrEmpty(txt_SinkType_Logging1.Text))
                btn_Save.IsEnabled = true;
            else if (_logInfoChanged && _agentSettings.SinkType.Equals("SignalR") && !string.IsNullOrEmpty(txt_SinkType_Logging1.Text)
                && !string.IsNullOrEmpty(txt_SinkType_Logging2.Text) && !string.IsNullOrEmpty(txt_SinkType_Logging3.Text)
                && !string.IsNullOrEmpty(txt_SinkType_Logging4.Text))
                btn_Save.IsEnabled = true;
            else
                btn_Save.IsEnabled = false;

            UpdateConnectButtonState();
        }
        private void OnSinkSelectionChange()
        {
            switch (cmb_SinkType.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "File":
                    // Update Label Properties
                    lbl_SinkType_Logging1.Content = "File Path";
                    lbl_SinkType_Logging1.ToolTip = "File Path to write logs to";

                    // Hide Logging2, Logging3, Logging4
                    pnl_SinkType_Logging2.Visibility = Visibility.Hidden;
                    pnl_SinkType_Logging3.Visibility = Visibility.Hidden;
                    pnl_SinkType_Logging4.Visibility = Visibility.Hidden;

                    // Shrink Window Size
                    if (!_windowHeightReduced)
                    {
                        wndMain.Height -= (pnl_SinkType_Logging1.ActualHeight + pnl_SinkType_Logging2.ActualHeight +
                                           pnl_SinkType_Logging3.ActualHeight + pnl_SinkType_Logging4.ActualHeight);
                        _windowHeightReduced = true;
                    }

                    // Update UI for SinkType_Save Button
                    pnl_SinkType_Save.SetValue(Grid.RowProperty, 2);

                    txt_SinkType_Logging1.Text = _agentSettings.SinkType.Equals("File") ? _agentSettings.LoggingValue1 : string.Empty;

                    break;
                case "Http":
                    // Update Label Properties
                    lbl_SinkType_Logging1.Content = "URI";
                    lbl_SinkType_Logging1.ToolTip = "URI to send logs to";

                    // Hide Logging2, Logging3, Logging4
                    pnl_SinkType_Logging2.Visibility = Visibility.Hidden;
                    pnl_SinkType_Logging3.Visibility = Visibility.Hidden;
                    pnl_SinkType_Logging4.Visibility = Visibility.Hidden;

                    // Shrink Window Size
                    if (!_windowHeightReduced)
                    {
                        wndMain.Height -= (pnl_SinkType_Logging1.ActualHeight + pnl_SinkType_Logging2.ActualHeight +
                                           pnl_SinkType_Logging3.ActualHeight + pnl_SinkType_Logging4.ActualHeight);
                        _windowHeightReduced = true;
                    }

                    // Update UI for SinkType_Save Button
                    pnl_SinkType_Save.SetValue(Grid.RowProperty, 2);

                    txt_SinkType_Logging1.Text = _agentSettings.SinkType.Equals("Http") ? _agentSettings.LoggingValue1 : string.Empty;

                    break;
                case "SignalR":
                    // Update Labels Properties
                    lbl_SinkType_Logging1.Content = "URL";
                    lbl_SinkType_Logging2.Content = "Hub";
                    lbl_SinkType_Logging3.Content = "Group Names";
                    lbl_SinkType_Logging4.Content = "User IDs";
                    lbl_SinkType_Logging1.ClearValue(Label.ToolTipProperty);
                    lbl_SinkType_Logging2.ClearValue(Label.ToolTipProperty);
                    lbl_SinkType_Logging3.ClearValue(Label.ToolTipProperty);
                    lbl_SinkType_Logging4.ClearValue(Label.ToolTipProperty);

                    // Show Logging2, Logging3, Logging4
                    pnl_SinkType_Logging2.Visibility = Visibility.Visible;
                    pnl_SinkType_Logging3.Visibility = Visibility.Visible;
                    pnl_SinkType_Logging4.Visibility = Visibility.Visible;

                    // Expand Window Size
                    if (_windowHeightReduced)
                    {
                        wndMain.Height += (pnl_SinkType_Logging1.ActualHeight + pnl_SinkType_Logging2.ActualHeight +
                                       pnl_SinkType_Logging3.ActualHeight + pnl_SinkType_Logging4.ActualHeight);
                        _windowHeightReduced = false;
                    }

                    // Update UI for SinkType_Save Button
                    pnl_SinkType_Save.SetValue(Grid.RowProperty, 5);

                    if (_agentSettings.SinkType.Equals("SignalR"))
                    {
                        txt_SinkType_Logging1.Text = _agentSettings.LoggingValue1;
                        txt_SinkType_Logging2.Text = _agentSettings.LoggingValue2;
                        txt_SinkType_Logging3.Text = _agentSettings.LoggingValue3;
                        txt_SinkType_Logging4.Text = _agentSettings.LoggingValue4;
                    }
                    else
                    {
                        txt_SinkType_Logging1.Text = string.Empty;
                        txt_SinkType_Logging2.Text = string.Empty;
                        txt_SinkType_Logging3.Text = string.Empty;
                        txt_SinkType_Logging4.Text = string.Empty;
                    }

                    break;
            }
        }

        #endregion
    }
}
