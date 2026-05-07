using System.ComponentModel.DataAnnotations;

namespace MVC_web_projekt_vjezba.Models;

public class StorageDevice
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CapacityInGb { get; set; }
    public double FreeSpaceInGb { get; set; }
    public string DevicePath { get; set; } = string.Empty;
    public bool IsExternal { get; set; }
    public virtual ICollection<LocalMediaFile> MediaFiles { get; set; } = new List<LocalMediaFile>();
    public virtual ICollection<LocalMediaLibrary> Libraries { get; set; } = new List<LocalMediaLibrary>();
}