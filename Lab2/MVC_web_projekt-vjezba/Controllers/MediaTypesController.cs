using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Models.ViewModels;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class MediaTypesController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public MediaTypesController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var mediaTypes = _repository.GetMediaTypes()
            .OrderBy(type => type.ToString())
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Media Types"));

        return View(mediaTypes);
    }

    public IActionResult Details(string id)
    {
        if (!_repository.TryGetMediaType(id, out var mediaType))
        {
            return NotFound();
        }

        var model = new MediaTypeDetailsViewModel
        {
            MediaType = mediaType,
            Files = _repository.GetMediaFilesByType(mediaType)
                .OrderByDescending(file => file.AddedAt)
                .ToList()
        };

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Media Types", "Index", "MediaTypes"),
            Current(mediaType.ToString()));

        return View(model);
    }
}
