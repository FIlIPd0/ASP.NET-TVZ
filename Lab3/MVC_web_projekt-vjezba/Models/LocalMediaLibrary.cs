using System.ComponentModel.DataAnnotations;

namespace MVC_web_projekt_vjezba.Models;

public class LocalMediaLibrary
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    public virtual ICollection<StorageDevice> StorageDevices { get; set; } = new List<StorageDevice>();
}