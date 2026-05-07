using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_web_projekt_vjezba.Models;

public class MediaComment
{
    [Key]
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual AppUser Author { get; set; } = null!;
    [ForeignKey(nameof(MediaFile))]
    public int MediaFileId { get; set; }
    public virtual LocalMediaFile MediaFile { get; set; } = null!;
}