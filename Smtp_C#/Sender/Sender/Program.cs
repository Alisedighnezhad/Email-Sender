using System.ComponentModel;
using System.Net;
using System.Net.Mail;
namespace Sender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailMessage mail = new MailMessage();;
            SmtpClient smtp = new SmtpClient();
            string from = string.Empty;
            Console.WriteLine("type your mail subject");
            mail.Subject = Console.ReadLine();
            Console.WriteLine("type body of mail");
            mail.Body = Console.ReadLine();
            Console.WriteLine("type your email");
            int i = 0; 
            while (i < 1 )
            {
                from =  Console.ReadLine();
                if( from != null)
                {
                    foreach(char atsine in from)
                    {
                        if ( atsine ==  '@')
                        {
                            mail.From = new MailAddress(from);
                            i++;
                            break;
                        }
                    }
                    if(i == 1)
                        break;//not importent becouse if i eqouls 1 laredy while is breacked
                    else
                        Console.WriteLine("not eamil format \n try again : ");
                }
                else
                    Console.WriteLine("we cant connect an nothing :)");
            }
            Console.WriteLine("ok now time to type your resivers");
            while (true)
            {
                string to = Console.ReadLine();
                if (to != null)
                {
                    if (to == "finish")
                        break;
                    foreach (char atsine in to)
                    {
                        if (atsine == '@')
                        {
                            mail.To.Add(to);
                        }
                    }
                }
            }
            Console.WriteLine("Now time to loging :)");
            while (true)
            {
                try
                {
                    Console.WriteLine("type your smtp server");
                    smtp.Host = Console.ReadLine();
                    Console.WriteLine("port:");
                    smtp.Port = int.Parse(Console.ReadLine());
                    Console.WriteLine("pass : ");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(from, Console.ReadLine());
                    smtp.EnableSsl = true;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "\r its your eroor try again : " + "\n");
                }
            }
            Console.WriteLine("sending time...... :)");
            smtp.Send(mail);
            Console.WriteLine("complate :) ");
        }
    }
}