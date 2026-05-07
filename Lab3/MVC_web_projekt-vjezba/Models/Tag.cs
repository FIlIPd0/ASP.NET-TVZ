using System.ComponentModel.DataAnnotations;

namespace MVC_web_projekt_vjezba.Models;

public class Tag
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ColorHex { get; set; } = string.Empty;
    public virtual ICollection<LocalMediaFile> MediaFiles { get; set; } = new List<LocalMediaFile>();
}