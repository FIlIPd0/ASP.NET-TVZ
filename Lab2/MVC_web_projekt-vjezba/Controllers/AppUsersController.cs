using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Repositories;

namespace MVC_web_projekt_vjezba.Controllers;

public class AppUsersController : AppBaseController
{
    private readonly MediaMockRepository _repository;

    public AppUsersController(MediaMockRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var users = _repository.GetUsers()
            .OrderBy(user => user.Username)
            .ToList();

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Current("Users"));

        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _repository.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }

        SetBreadcrumbs(
            Crumb("Home", "Index", "Home"),
            Crumb("Users", "Index", "AppUsers"),
            Current(user.Username));

        return View(user);
    }
}
