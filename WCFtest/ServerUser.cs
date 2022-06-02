
using System.ServiceModel;

namespace WCFtest
{
    internal class ServerUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; } //для того, чтобы сервис знал, как к экземпляру класса обратиться

    }
}
