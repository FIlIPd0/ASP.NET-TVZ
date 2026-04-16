namespace MVC_web_projekt_vjezba.Models;

public class MediaComment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public AppUser Author { get; set; } = null!;
}