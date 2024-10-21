using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBridge
{
    public class TextNotification : Notification
    {
        private string _message;

        public TextNotification(IMessageSender messageSender, string message)
            : base(messageSender)
        {
            _message = message;
        }

        public override void Send(string recipient)
        {
            _messageSender.SendMessage(recipient, _message);
        }
    }
}
