using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_web_projekt_vjezba.Models;

public class LocalMediaFile
{
    [Key]
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public MediaType MediaType { get; set; }
    public double SizeInMb { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime AddedAt { get; set; }
    public bool IsFavorite { get; set; }
    [ForeignKey(nameof(Owner))]
    public int OwnerId { get; set; }
    public virtual AppUser Owner { get; set; } = null!;
    [ForeignKey(nameof(StorageDevice))]
    public int StorageDeviceId { get; set; }
    public virtual StorageDevice StorageDevice { get; set; } = null!;
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    public virtual ICollection<MediaComment> Comments { get; set; } = new List<MediaComment>();
}