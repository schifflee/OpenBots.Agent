using OpenBots.Agent.Core.Infrastructure;
using OpenBots.Agent.Core.Model;
using OpenBots.Service.Client.Server;

namespace OpenBots.Service.Client
{
    public class WindowsServiceEndPoint : IWindowsServiceEndPoint
    {
        public ServerResponse ConnectToServer(ServerConnectionSettings settings)
        {
            // HttpServerClient.Instance.Connect() -> APIHandler.Connect()
            //|-> Update _serverSettings
            //|-> Return _serverSettings

            return HttpServerClient.Instance.Connect(settings);
        }

        public ServerResponse DisconnectFromServer(ServerConnectionSettings settings)
        {
            // HttpServerClient.Instance.Disconnect() -> APIHandler.Disconnect()
            //|-> Update _serverSettings
            //|-> Return _serverSettings

            return HttpServerClient.Instance.Disconnect(settings);
        }

        public ServerConnectionSettings GetConnectionSettings()
        {
            return HttpServerClient.Instance?.ServerSettings ?? null;
        }

        public bool IsAlive()
        {
            return ServiceController.Instance.IsServiceAlive;
        }

        public bool IsConnected()
        {
            return HttpServerClient.Instance?.ServerSettings?.ServerConnectionEnabled ?? false;
        }
    }
}
