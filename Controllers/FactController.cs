// FactController.cs
using Microsoft.AspNetCore.Mvc;
using CatGifApi.Models;
using CatGifApi.Services;

namespace CatGifApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactController : ControllerBase
    {
        private readonly CatFactService _catFactService;
        private readonly GiphyService _giphyService;
        private readonly InMemoryHistoryService _historyService;

        public FactController(
            CatFactService catFactService,
            GiphyService giphyService,
            InMemoryHistoryService historyService)
        {
            _catFactService = catFactService;
            _giphyService = giphyService;
            _historyService = historyService;
        }

        [HttpGet("fact")]
        public async Task<IActionResult> GetFact()
        {
            var fact = await _catFactService.GetRandomFactAsync();
            return Ok(fact?.Fact);
        }

        [HttpGet("gif")]
        public async Task<IActionResult> GetGif([FromQuery] string query)
        {
            var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var searchQuery = string.Join(" ", words.Take(3));

            var gifUrl = await _giphyService.SearchGifAsync(searchQuery);

            if (string.IsNullOrEmpty(gifUrl))
                return NotFound("No GIF found.");

            var history = new FactHistory
            {
                FullFact = query,
                QueryWords = searchQuery,
                GifUrl = gifUrl
            };

            await _historyService.AddHistoryAsync(history);

            return Ok(new { gifUrl });
        }
    }
}