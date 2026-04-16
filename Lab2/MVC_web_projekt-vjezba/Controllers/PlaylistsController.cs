using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class PlaylistsController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public PlaylistsController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var playlists = _repository.GetPlaylists()
            .OrderByDescending(playlist => playlist.CreatedAt)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Playlists"));

        return View(playlists);
    }

    public IActionResult Details(int id)
    {
        var playlist = _repository.GetPlaylistById(id);
        if (playlist is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Playlists", "Index", "Playlists"),
            Current(playlist.Name));

        return View(playlist);
    }
}
