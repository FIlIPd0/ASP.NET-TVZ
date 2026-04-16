namespace MVC_web_projekt_vjezba.Models;

public class StorageDevice
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CapacityInGb { get; set; }
    public double FreeSpaceInGb { get; set; }
    public string DevicePath { get; set; } = string.Empty;
    public bool IsExternal { get; set; }
    public List<LocalMediaFile> MediaFiles { get; set; } = new();
}