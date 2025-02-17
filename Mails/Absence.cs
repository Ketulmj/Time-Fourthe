namespace TimeFourthe.Mails
{
    public class Absence
    {
        public static void MailOtp()
        {
            string teacher = "Ketul mj";
            string subject = "DSA";
            string date = DateTime.Now.ToString("d/M/yyyy");
            string orgName = "Web University";
            string title = "Urgent : No Class Today – Teacher Absent";
            string[] recipients = ["cclab01234@gmail.com"];
            string html = @$"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Teacher Absence Notice</title>
    <style>
        body {{
            font-family: 'Arial', sans-serif;
            background-color: #121212;
            color: #e0e0e0;
            text-align: center;
            padding: 20px;
        }}
        .container {{
            background: #1e1e1e;
            padding: 30px;
            max-width: 500px;
            margin: auto;
            box-shadow: 0px 0px 10px rgba(255, 255, 255, 0.1);
            border-radius: 8px;
        }}
        .notice {{
            font-size: 18px;
            margin-top: 20px;
            line-height: 1.6;
        }}
        .highlight {{
            font-weight: bold;
            color: #bb86fc;
        }}
        h2 {{
            font-size: 24px;
            margin-bottom: 15px;
            color: #ffffff;
        }}
        p {{
            color: #bdbdbd;
        }}
        .footer {{
            margin-top: 30px;
            font-size: 16px;
            font-weight: bold;
            color: #bb86fc;
        }}
        .footer1 {{
            font-size: 18px;
            font-weight: bold;
            color: #bb86fc;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h2>📢 Teacher Absence Notification</h2>
        <p>Dear Students,</p>
        <p class='notice'>This is to inform you that <span class='highlight' id='teacherName'>{teacher}</span>, your <span class='highlight' id='subject'>{subject}</span> instructor, will be unavailable on <span class='highlight' id='date'>{date}</span>. Please make the necessary adjustments to your schedule.</p>
        <p class='footer'>Best Regards,</p>
        <p class='footer1'><strong>{orgName}</strong></p>
    </div>
</body>
</html>";

            MailSender.SendMail(recipients, html, title);
        }
    }
}
