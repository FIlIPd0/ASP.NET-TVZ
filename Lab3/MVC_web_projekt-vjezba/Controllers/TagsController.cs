using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class TagsController : AppBaseController
{
    private readonly MediaRepository _repository;

    public TagsController(MediaRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var tags = _repository.GetTags()
            .OrderByDescending(tag => tag.MediaFiles.Count)
            .ThenBy(tag => tag.Name)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Tags"));

        return View(tags);
    }

    public IActionResult Details(int id)
    {
        var tag = _repository.GetTagById(id);
        if (tag is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Tags", "Index", "Tags"),
            Current(tag.Name));

        return View(tag);
    }
}
