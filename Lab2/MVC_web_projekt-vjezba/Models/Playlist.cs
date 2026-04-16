namespace MVC_web_projekt_vjezba.Models;

public class Playlist
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public AppUser Owner { get; set; } = null!;
    public List<LocalMediaFile> MediaFiles { get; set; } = new();
}