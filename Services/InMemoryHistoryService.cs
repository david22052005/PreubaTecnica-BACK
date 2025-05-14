using CatGifApi.Models;

namespace CatGifApi.Services;

public class InMemoryHistoryService
{
    private readonly List<FactHistory> _history = new();

    public Task<List<FactHistory>> GetHistoryAsync()
    {
        return Task.FromResult(_history);
    }

    public Task AddHistoryAsync(FactHistory history)
    {
        _history.Add(history);
        return Task.CompletedTask;
    }
}