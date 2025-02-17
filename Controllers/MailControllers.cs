using Microsoft.AspNetCore.Mvc;
using TimeFourthe.Entities;
using TimeFourthe.Mails;
using TimeFourthe.Services;

namespace TimeFourthe.Controllers
{
    [Route("api")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly TimetableService _timetableService;
        public MailController(TimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> OtpMail()
        {
            Otp.MailOtp();
            return Ok(new { id = 'f' });
        }
        [HttpPost("send-absent")]
        public async Task<IActionResult> AbsenceMail()
        {
            Absence.MailOtp();
            return Ok(new { id = 'f' });
        }
    }
}