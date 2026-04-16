using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class StorageDevicesController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public StorageDevicesController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var devices = _repository.GetStorageDevices()
            .OrderBy(device => device.Name)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Storage Devices"));

        return View(devices);
    }

    public IActionResult Details(int id)
    {
        var device = _repository.GetStorageDeviceById(id);
        if (device is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Storage Devices", "Index", "StorageDevices"),
            Current(device.Name));

        return View(device);
    }
}
