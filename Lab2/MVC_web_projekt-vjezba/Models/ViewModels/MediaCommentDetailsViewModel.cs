using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Models.ViewModels;

public class MediaCommentDetailsViewModel
{
    public MediaComment Comment { get; set; } = null!;
    public LocalMediaFile? ParentFile { get; set; }
}
