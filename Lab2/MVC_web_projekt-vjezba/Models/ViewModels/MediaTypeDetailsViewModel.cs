using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Models.ViewModels;

public class MediaTypeDetailsViewModel
{
    public MediaType MediaType { get; set; }
    public IReadOnlyList<LocalMediaFile> Files { get; set; } = [];
}
