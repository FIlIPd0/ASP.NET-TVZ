using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class LocalMediaFilesController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public LocalMediaFilesController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var files = _repository.GetMediaFiles()
            .OrderByDescending(file => file.AddedAt)
            .ThenBy(file => file.FileName)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Media Files"));

        return View(files);
    }

    public IActionResult Details(int id)
    {
        var file = _repository.GetMediaFileById(id);
        if (file is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Media Files", "Index", "LocalMediaFiles"),
            Current(file.FileName));

        return View(file);
    }
}
