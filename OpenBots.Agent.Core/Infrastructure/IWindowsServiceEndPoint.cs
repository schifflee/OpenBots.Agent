using System.ServiceModel;
using OpenBots.Agent.Core.Model;

namespace OpenBots.Agent.Core.Infrastructure
{
    [ServiceContract]
    public interface IWindowsServiceEndPoint
    {
        [OperationContract]
        ServerResponse ConnectToServer(ServerConnectionSettings settings);

        [OperationContract]
        ServerResponse DisconnectFromServer(ServerConnectionSettings settings);

        [OperationContract]
        bool IsConnected();

        [OperationContract]
        bool IsAlive();

        [OperationContract]
        ServerConnectionSettings GetConnectionSettings();
    }
}

