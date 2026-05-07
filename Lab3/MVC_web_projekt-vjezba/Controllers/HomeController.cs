using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Models;
using MVC_web_projekt_vjezba.Models.ViewModels;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class HomeController : AppBaseController
{
    private readonly MediaRepository _repository;

    public HomeController(MediaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("/pocetna")]
    public IActionResult Index()
    {
        var mediaFiles = _repository.GetMediaFiles();
        var tags = _repository.GetTags();
        var model = new HomeDashboardViewModel
        {
            TotalUsers = _repository.GetUsers().Count,
            TotalMediaFiles = mediaFiles.Count,
            TotalPlaylists = _repository.GetPlaylists().Count,
            TotalLibraries = _repository.GetLibraries().Count,
            TotalComments = _repository.GetComments().Count,
            TypeSnapshots = Enum.GetValues<MediaType>()
                .Select(type => new MediaTypeSnapshot
                {
                    Label = type.ToString(),
                    Count = mediaFiles.Count(file => file.MediaType == type)
                })
                .OrderByDescending(item => item.Count)
                .ToList(),
            DeviceSnapshots = _repository.GetStorageDevices()
                .Select(device => new DeviceUsageSnapshot
                {
                    DeviceId = device.Id,
                    Name = device.Name,
                    CapacityInGb = device.CapacityInGb,
                    FreeSpaceInGb = device.FreeSpaceInGb,
                    IsExternal = device.IsExternal
                })
                .OrderByDescending(device => device.UsedPercent)
                .ToList(),
            TopTags = tags
                .OrderByDescending(tag => tag.MediaFiles.Count)
                .Take(8)
                .Select(tag => new TagUsageSnapshot
                {
                    TagId = tag.Id,
                    Name = tag.Name,
                    ColorHex = tag.ColorHex,
                    Count = tag.MediaFiles.Count
                })
                .ToList(),
            RecentMedia = mediaFiles
                .OrderByDescending(file => file.AddedAt)
                .Take(7)
                .Select(file => new RecentMediaSnapshot
                {
                    MediaFileId = file.Id,
                    FileName = file.FileName,
                    OwnerName = file.Owner.Username,
                    AddedAt = file.AddedAt,
                    TypeLabel = file.MediaType.ToString()
                })
                .ToList()
        };

        SetBreadcrumbs(Current("Home"));
        return View(model);
    }

    public IActionResult Privacy()
    {
        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Privacy"));

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Error"));

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}