using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OpenBots.Agent.Client
{
    /// <summary>
    /// Interaction logic for ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string generalError, string statusCode, string detailedErrorMessage)
        {
            InitializeComponent();
            lbl_GeneralErrorMsg.Content = generalError;
            lbl_StatusCodeValue.Content = statusCode;
            txtBlock_ErrorMessage.Text = detailedErrorMessage;
        }

        private void OnClick_OKBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
    }
}
