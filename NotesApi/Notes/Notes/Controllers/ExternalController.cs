using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly INoteService _noteService;

        public ExternalController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet("performance/getnote")]
        public ActionResult<long> GetNotePerformance()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int  i = 0; i < 1000; i++)
            {
                _noteService.GetUserNotes(1);
            }

            stopwatch.Stop();
            
            var elapsed = stopwatch.ElapsedMilliseconds;
            if (elapsed > 100000)
            {
                Log.Warning($"This endpoint resulted in {elapsed}ms");
            }
            else
            {
                Log.Information($"This endpoint resulted in {elapsed}ms");
            }
            
            return elapsed;
        }
    }
}
