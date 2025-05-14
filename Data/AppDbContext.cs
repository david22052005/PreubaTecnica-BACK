// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using CatGifApi.Models;

namespace CatGifApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<FactHistory> Histories { get; set; } = null!;
}