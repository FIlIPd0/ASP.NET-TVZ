namespace MVC_web_projekt_vjezba.Models.ViewModels;

public class HomeDashboardViewModel
{
    public int TotalUsers { get; set; }
    public int TotalMediaFiles { get; set; }
    public int TotalPlaylists { get; set; }
    public int TotalLibraries { get; set; }
    public int TotalComments { get; set; }
    public IReadOnlyList<MediaTypeSnapshot> TypeSnapshots { get; set; } = [];
    public IReadOnlyList<DeviceUsageSnapshot> DeviceSnapshots { get; set; } = [];
    public IReadOnlyList<TagUsageSnapshot> TopTags { get; set; } = [];
    public IReadOnlyList<RecentMediaSnapshot> RecentMedia { get; set; } = [];
}

public class MediaTypeSnapshot
{
    public string Label { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class DeviceUsageSnapshot
{
    public int DeviceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CapacityInGb { get; set; }
    public double FreeSpaceInGb { get; set; }
    public bool IsExternal { get; set; }
    public double UsedPercent => CapacityInGb == 0 ? 0 : Math.Round((CapacityInGb - FreeSpaceInGb) / CapacityInGb * 100, 1);
}

public class TagUsageSnapshot
{
    public int TagId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ColorHex { get; set; } = "#4B5D67";
    public int Count { get; set; }
}

public class RecentMediaSnapshot
{
    public int MediaFileId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public DateTime AddedAt { get; set; }
    public string TypeLabel { get; set; } = string.Empty;
}
