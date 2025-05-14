// HistoryController.cs
using Microsoft.AspNetCore.Mvc;
using CatGifApi.Models;
using CatGifApi.Services;

namespace CatGifApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly InMemoryHistoryService _historyService;

        public HistoryController(InMemoryHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _historyService.GetHistoryAsync();
            return Ok(history);
        }
    }
}