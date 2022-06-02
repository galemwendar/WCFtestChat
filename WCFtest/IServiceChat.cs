using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFtest
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof (IServerChatCallBack))] //указываем servicecontract, что есть интерфейс коллбэка
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect( int id );

        [OperationContract (IsOneWay = true)] //для того, чтобы не ждать ответа сервера
        void SendMsg( string msg, int id );


    }

    public interface IServerChatCallBack //интерфейс для того, чтобы сервер мог разослать всем клиентам сообщение
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback ( string msg );
    }
}
