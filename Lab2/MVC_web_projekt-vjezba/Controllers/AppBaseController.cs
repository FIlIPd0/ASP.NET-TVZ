using Microsoft.AspNetCore.Mvc;
using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Controllers;

public abstract class AppBaseController : Controller
{
    protected BreadcrumbItem Crumb(string label, string action, string controller, object? values = null)
    {
        return new BreadcrumbItem(label, Url.Action(action, controller, values));
    }

    protected BreadcrumbItem Current(string label)
    {
        return new BreadcrumbItem(label);
    }

    protected void SetBreadcrumbs(params BreadcrumbItem[] breadcrumbs)
    {
        ViewData["Breadcrumbs"] = breadcrumbs.ToList();
    }
}
