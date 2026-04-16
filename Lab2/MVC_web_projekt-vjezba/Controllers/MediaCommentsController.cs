using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Models.ViewModels;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class MediaCommentsController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public MediaCommentsController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var comments = _repository.GetComments()
            .OrderByDescending(comment => comment.CreatedAt)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Comments"));

        return View(comments);
    }

    public IActionResult Details(int id)
    {
        var comment = _repository.GetCommentById(id);
        if (comment is null)
        {
            return NotFound();
        }

        var model = new MediaCommentDetailsViewModel
        {
            Comment = comment,
            ParentFile = _repository.GetFileByCommentId(comment.Id)
        };

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Comments", "Index", "MediaComments"),
            Current($"Comment #{comment.Id}"));

        return View(model);
    }
}
