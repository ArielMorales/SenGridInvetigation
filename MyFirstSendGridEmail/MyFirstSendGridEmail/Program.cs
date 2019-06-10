using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MyFirstSendGridEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            //Aquí va la llave API
            var client = new SendGridClient("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");


            var from = new EmailAddress("grupoumi2019@gmail.com", "Grupo Umi");
            var subject = "Hello World from the Twilio SendGrid CSharp Library Helper!";
            var to = new EmailAddress("grupoumi2019@gmail.com", "Grupo Umi");
            var plainTextContent = "Hello, Email from the helper [SendSingleEmailAsync]!";
            var htmlContent = "<strong>Hello, Email from the helper! [SendSingleEmailAsync]</strong>";

            //Con el MailHelper se construye el correo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            //Acá se envía el correo
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine("\n\nPress <Enter> to continue.");
            Console.ReadKey();
        }
    }
}