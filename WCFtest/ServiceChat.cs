using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFtest
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    //Обычно для каждого подключения создается отдельный экземпляр сервиса, но у нас чат, и экземпляр должен быть один.
    // для этого 
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)] //описал поведение сервиса, чтобы он не создавался при вызове или сессии
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            { ID = nextId, Name = name, operationContext = OperationContext.Current};
            nextId++;
            SendMsg(" " + user.Name + " подключился к чату!",0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(" " + user.Name + " покинул чат!", 0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users) // send msg to all users
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(x => x.ID == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }

                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallBack>().MsgCallback(answer); //for send message to user
            }
        }
    }
}
