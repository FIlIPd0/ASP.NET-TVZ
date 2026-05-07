using System.ComponentModel.DataAnnotations;

namespace MVC_web_projekt_vjezba.Models;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
    public bool IsPremium { get; set; }
    public virtual ICollection<LocalMediaFile> UploadedFiles { get; set; } = new List<LocalMediaFile>();
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    public virtual ICollection<LocalMediaLibrary> Libraries { get; set; } = new List<LocalMediaLibrary>();
}