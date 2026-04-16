namespace MVC_web_projekt_vjezba.Models;

public class LocalMediaFile
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public MediaType MediaType { get; set; }
    public double SizeInMb { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime AddedAt { get; set; }
    public bool IsFavorite { get; set; }
    public AppUser Owner { get; set; } = null!;
    public StorageDevice StorageDevice { get; set; } = null!;
    public List<Tag> Tags { get; set; } = new();
    public List<Playlist> Playlists { get; set; } = new();
    public List<MediaComment> Comments { get; set; } = new();
}