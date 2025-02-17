
namespace TimeFourthe.Mails
{
    public class Auth
    {
        public static void MailOtp(List<string> org)
        {
            string orgName = org[1];
            string orgId=org[0];
            string title = "Authentication of Organization";
            string[] recipients = ["cclab01234@gmail.com"];
            string html = @$"<!DOCTYPE html>
                    <html>
                    <head>
                        <style>
                            .button {{
                                display: inline-block;
                                padding: 10px 20px;
                                font-size: 16px;
                                color: white;
                                text-decoration: none;
                                border-radius: 5px;
                                margin: 10px;
                            }}
                            .yes {{ background-color: green; }}
                            .no {{ background-color: red; }}
                        </style>
                    </head>
                    <body>
                        <p>{orgName} is request for signup? </p>
                        <a href='http://localhost:5140/api/get/auth?id={orgId}&answer=true' class='button yes'>YES</a>
                        <a href='http://localhost:5140/api/get/auth?id={orgId}&answer=false' class='button no'>NO</a>
                    </body>
                    </html>";

            MailSender.SendMail(recipients, html, title);
        }
    }
}
