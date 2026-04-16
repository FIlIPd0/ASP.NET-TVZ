namespace MVC_web_projekt_vjezba.Models;

public class AppUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
    public bool IsPremium { get; set; }
    public List<LocalMediaFile> UploadedFiles { get; set; } = new();
    public List<Playlist> Playlists { get; set; } = new();
}