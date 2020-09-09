using OpenBots.Agent.Core.Model;
using OpenBots.Service.API;
using OpenBots.Service.API.Model;
using System;
using System.Collections.Generic;
using System.Timers;

namespace OpenBots.Service.Client.Server
{
    public class HttpServerClient
    {
        private Timer _heartbeatTimer;
        public ServerConnectionSettings ServerSettings { get; set; }
        public static HttpServerClient Instance
        {
            get
            {
                if (instance == null)
                    instance = new HttpServerClient();

                return instance;
            }
        }
        private static HttpServerClient instance;

        private HttpServerClient()
        {
        }
        
        public void Initialize()
        {
            ServerSettings = new ServerConnectionSettings();
        }

        private void StartHeartBeatTimer()
        {
            if (ServerSettings.ServerConnectionEnabled)
            {
                //handle for reinitialization
                if (_heartbeatTimer != null)
                {
                    _heartbeatTimer.Elapsed -= Heartbeat_Elapsed;
                }

                //setup heartbeat to the server
                _heartbeatTimer = new Timer();
                _heartbeatTimer.Interval = 5000;
                _heartbeatTimer.Elapsed += Heartbeat_Elapsed;
                _heartbeatTimer.Enabled = true;
            }
        }

        private void StopHeartBeatTimer()
        {
            if (_heartbeatTimer != null)
            {
                _heartbeatTimer.Enabled = false;
                _heartbeatTimer.Elapsed -= Heartbeat_Elapsed;
            }
        }

        private void Heartbeat_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                int statusCode = APIHandler.SendAgentHeartBeat(
                    ServerSettings.ServerURL,
                    "6fd978a7-3bff-4396-986e-4389f5556f1f",
                    new List<Operation>()
                    {
                            new Operation(){ Op = "replace", Path = "/lastReportedOn", Value = DateTime.Now.ToString("s")},
                            new Operation(){ Op = "replace", Path = "/lastReportedStatus", Value = "SomeStatus"},
                            new Operation(){ Op = "replace", Path = "/lastReportedWork", Value = "SomeWork"},
                            new Operation(){ Op = "replace", Path = "/lastReportedMessage", Value = "SomeMessage"},
                            new Operation(){ Op = "replace", Path = "/isHealthy", Value = true}
                    });

                if (statusCode != 200)
                    ServerSettings.ServerConnectionEnabled = false;
            }
            catch (Exception ex)
            {
            }
        }
        
        public void UnInitialize()
        {
            StopHeartBeatTimer();
        }

        public Boolean IsConnected()
        {
            return ServerSettings?.ServerConnectionEnabled ?? false;
        }

        public ServerResponse Connect(ServerConnectionSettings connectionSettings)
        {
            ServerSettings = connectionSettings;
            try
            {
                // API Call to Connect
                var apiResponse = APIHandler.ConnectAgent(
                    ServerSettings.ServerURL,
                    ServerSettings.DNSHost,
                    ServerSettings.MACAddress
                    );

                // Update Server Settings
                ServerSettings.ServerConnectionEnabled = true;
                ServerSettings.AgentId = apiResponse.Data.Id.ToString();

                // Form Server Response
                return new ServerResponse(ServerSettings.AgentId, apiResponse.StatusCode.ToString());

                // On Successful Connection with Server
                ////StartHeartBeatTimer();
            }
            catch (Exception ex)
            {
                // Update Server Settings
                ServerSettings.ServerConnectionEnabled = false;
                ServerSettings.AgentId = string.Empty;

                // Form Server Response
                return new ServerResponse(null,
                    ex.GetType().GetProperty("ErrorCode").GetValue(ex, null).ToString(),
                    ex.GetType().GetProperty("ErrorContent").GetValue(ex, null).ToString());
            }
        }

        public ServerResponse Disconnect(ServerConnectionSettings connectionSettings)
        {
            try
            {
                // API Call to Disconnect
                var apiResponse = APIHandler.DisconnectAgent(
                        ServerSettings.ServerURL,
                        ServerSettings.DNSHost,
                        ServerSettings.MACAddress,
                        ServerSettings.AgentId
                        );

                // Update settings
                //ServerSettings = connectionSettings;
                ServerSettings.ServerConnectionEnabled = false;
                ServerSettings.AgentId = "";

                // After Disconnecting from Server
                ////StopHeartBeatTimer();

                // Form Server Response
                return new ServerResponse(ServerSettings.AgentId, apiResponse.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                // Form Server Response
                return new ServerResponse(null,
                    ex.GetType().GetProperty("ErrorCode").GetValue(ex, null).ToString(),
                    ex.GetType().GetProperty("ErrorContent").GetValue(ex, null).ToString());
            }
        }

    }
}
