// FactHistory.cs
namespace CatGifApi.Models;

public class FactHistory
{
    public int Id { get; set; }
    public DateTime SearchDate { get; } = DateTime.Now;
    public string FullFact { get; set; } = string.Empty;
    public string QueryWords { get; set; } = string.Empty;
    public string GifUrl { get; set; } = string.Empty;
}