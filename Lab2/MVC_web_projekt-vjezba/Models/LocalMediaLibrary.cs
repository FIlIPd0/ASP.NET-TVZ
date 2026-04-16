namespace MVC_web_projekt_vjezba.Models;

public class LocalMediaLibrary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<AppUser> Users { get; set; } = new();
    public List<Playlist> Playlists { get; set; } = new();
    public List<StorageDevice> StorageDevices { get; set; } = new();
}