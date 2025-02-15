using Microsoft.AspNetCore.Mvc;
using TimeFourthe.Entities;
using TimeFourthe.Services;

namespace TimeFourthe.Controllers
{
    [Route("api")]
    [ApiController]
    public class TimetablesController : ControllerBase
    {
        private readonly TimetableService _timetableService;
        public TimetablesController(TimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpPost("create-timetable")]
        public async Task<IActionResult> CreateTimetable([FromBody] TimetableData timetableData)
        {
            // BigInteger st = BigInteger.Parse(timetableData.StartTime.ToString());
            await _timetableService.InsertTimetableDataAsync(timetableData);
            return Ok(new { id = timetableData.tableId });
        }
    }
}