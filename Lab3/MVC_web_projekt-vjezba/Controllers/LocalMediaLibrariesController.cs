using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class LocalMediaLibrariesController : AppBaseController
{
    private readonly MediaRepository _repository;

    public LocalMediaLibrariesController(MediaRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var libraries = _repository.GetLibraries()
            .OrderBy(library => library.Name)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Libraries"));

        return View(libraries);
    }

    public IActionResult Details(int id)
    {
        var library = _repository.GetLibraryById(id);
        if (library is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Libraries", "Index", "LocalMediaLibraries"),
            Current(library.Name));

        return View(library);
    }
}
