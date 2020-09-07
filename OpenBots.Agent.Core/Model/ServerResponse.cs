using System.Runtime.Serialization;

namespace OpenBots.Agent.Core.Model
{
    [DataContract]
    public class ServerResponse
    {
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Message { get; set; }

        public ServerResponse(object data, string statusCode = null, string responseMessage = null)
        {
            Data = data;
            StatusCode = statusCode;
            Message = responseMessage;
        }
    }
}
