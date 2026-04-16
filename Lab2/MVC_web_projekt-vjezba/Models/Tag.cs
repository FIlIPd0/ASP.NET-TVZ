namespace MVC_web_projekt_vjezba.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ColorHex { get; set; } = string.Empty;
    public List<LocalMediaFile> MediaFiles { get; set; } = new();
}