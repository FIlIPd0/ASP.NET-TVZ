using Microsoft.EntityFrameworkCore;
using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Data;

public class MediaDbContext : DbContext
{
    public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; } = null!;
    public DbSet<LocalMediaFile> LocalMediaFiles { get; set; } = null!;
    public DbSet<LocalMediaLibrary> LocalMediaLibraries { get; set; } = null!;
    public DbSet<MediaComment> MediaComments { get; set; } = null!;
    public DbSet<Playlist> Playlists { get; set; } = null!;
    public DbSet<StorageDevice> StorageDevices { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
}
