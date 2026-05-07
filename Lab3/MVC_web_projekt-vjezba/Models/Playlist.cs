using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_web_projekt_vjezba.Models;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    [ForeignKey(nameof(Owner))]
    public int OwnerId { get; set; }
    public virtual AppUser Owner { get; set; } = null!;
    public virtual ICollection<LocalMediaFile> MediaFiles { get; set; } = new List<LocalMediaFile>();
    public virtual ICollection<LocalMediaLibrary> Libraries { get; set; } = new List<LocalMediaLibrary>();
}