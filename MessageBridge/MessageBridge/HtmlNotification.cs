using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html;

namespace MessageBridge
{
    public class HtmlNotification : Notification
    {
        private readonly string _documentPath;
        private readonly string _htmlContent;

        public HtmlNotification(IMessageSender messageSender, string htmlContent)
            : base(messageSender)
        {
            _htmlContent = htmlContent;
        }

        public override void Send(string recipient)
        {
            string formattedMessage = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>{_htmlContent}</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        margin: 20px;
                    }}
                    b {{
                        font-weight: bold;
                    }}
                </style>
            </head>
            <body>
                <h1>{recipient}</h1>
            </body>
            </html>";

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.Combine(@"G:\Three\Csh\ComputerAdapter\MessageBridge", "MessageBridge", "BIN228");
            targetDirectory = Path.GetFullPath(targetDirectory);
            targetDirectory = targetDirectory + "\\";

            string _documentPath = targetDirectory;

            _messageSender.SendMessage(recipient, formattedMessage);

            if (!Directory.Exists(_documentPath))
            {
                Directory.CreateDirectory(_documentPath);
            }

            string filePath = Path.Combine(_documentPath, "notification2.html");

            using (var document = new HTMLDocument(formattedMessage, "."))
            {
                document.Save(filePath);
                Console.WriteLine($"HTML document saved at: {filePath}");
            }

            OpenDocument(filePath);
        }

        private void OpenDocument(string filePath)
        {
            try
            {
                string browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                Process.Start(new ProcessStartInfo(browserPath, filePath) { UseShellExecute = true });
                Console.WriteLine("HTML document opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening document: {ex.Message}");
            }
        }
    }
}
