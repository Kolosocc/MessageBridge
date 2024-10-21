using MessageBridge;

namespace MessageBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SmsSender();

            Notification textEmailNotification = new TextNotification(emailSender, "Dalihe Email");
            Notification htmlEmailNotification = new HtmlNotification(emailSender, "Dalihe Html");
            Notification smsTextNotification = new TextNotification(smsSender, " SMS.");

            textEmailNotification.Send("vaseko228@gmail.com");
            htmlEmailNotification.Send("GOOOOOOOOOOOl!!!");
            smsTextNotification.Send("8 (800) 555 - 35 - 35");
        }
    }
}
