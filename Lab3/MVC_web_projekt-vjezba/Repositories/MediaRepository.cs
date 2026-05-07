using Microsoft.EntityFrameworkCore;
using MVC_web_projekt_vjezba.Data;
using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Repositories;

public class MediaRepository
{
    private readonly MediaDbContext _context;

    public MediaRepository(MediaDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<AppUser> GetUsers() => _context.AppUsers
        .Include(user => user.UploadedFiles)
        .Include(user => user.Playlists)
        .AsNoTracking()
        .ToList();

    public AppUser? GetUserById(int id) => _context.AppUsers
        .Include(user => user.UploadedFiles)
        .Include(user => user.Playlists)
            .ThenInclude(playlist => playlist.MediaFiles)
        .AsNoTracking()
        .FirstOrDefault(user => user.Id == id);

    public IReadOnlyList<Tag> GetTags() => _context.Tags
        .Include(tag => tag.MediaFiles)
        .AsNoTracking()
        .ToList();

    public Tag? GetTagById(int id) => _context.Tags
        .Include(tag => tag.MediaFiles)
            .ThenInclude(file => file.Owner)
        .Include(tag => tag.MediaFiles)
            .ThenInclude(file => file.StorageDevice)
        .AsNoTracking()
        .FirstOrDefault(tag => tag.Id == id);

    public IReadOnlyList<StorageDevice> GetStorageDevices() => _context.StorageDevices
        .Include(device => device.MediaFiles)
        .AsNoTracking()
        .ToList();

    public StorageDevice? GetStorageDeviceById(int id) => _context.StorageDevices
        .Include(device => device.MediaFiles)
            .ThenInclude(file => file.Owner)
        .AsNoTracking()
        .FirstOrDefault(device => device.Id == id);

    public IReadOnlyList<LocalMediaFile> GetMediaFiles() => _context.LocalMediaFiles
        .Include(file => file.Owner)
        .Include(file => file.StorageDevice)
        .AsNoTracking()
        .ToList();

    public LocalMediaFile? GetMediaFileById(int id) => _context.LocalMediaFiles
        .Include(file => file.Owner)
        .Include(file => file.StorageDevice)
        .Include(file => file.Tags)
        .Include(file => file.Playlists)
        .Include(file => file.Comments)
            .ThenInclude(comment => comment.Author)
        .AsNoTracking()
        .FirstOrDefault(file => file.Id == id);

    public IReadOnlyList<Playlist> GetPlaylists() => _context.Playlists
        .Include(playlist => playlist.Owner)
        .Include(playlist => playlist.MediaFiles)
        .AsNoTracking()
        .ToList();

    public Playlist? GetPlaylistById(int id) => _context.Playlists
        .Include(playlist => playlist.Owner)
        .Include(playlist => playlist.MediaFiles)
            .ThenInclude(file => file.Owner)
        .AsNoTracking()
        .FirstOrDefault(playlist => playlist.Id == id);

    public IReadOnlyList<LocalMediaLibrary> GetLibraries() => _context.LocalMediaLibraries
        .Include(library => library.Users)
        .Include(library => library.Playlists)
        .Include(library => library.StorageDevices)
        .AsNoTracking()
        .ToList();

    public LocalMediaLibrary? GetLibraryById(int id) => _context.LocalMediaLibraries
        .Include(library => library.Users)
        .Include(library => library.Playlists)
        .Include(library => library.StorageDevices)
        .AsNoTracking()
        .FirstOrDefault(library => library.Id == id);

    public IReadOnlyList<MediaComment> GetComments() => _context.MediaComments
        .Include(comment => comment.Author)
        .AsNoTracking()
        .ToList();

    public MediaComment? GetCommentById(int id) => _context.MediaComments
        .Include(comment => comment.Author)
        .Include(comment => comment.MediaFile)
            .ThenInclude(file => file.StorageDevice)
        .AsNoTracking()
        .FirstOrDefault(comment => comment.Id == id);

    public LocalMediaFile? GetFileByCommentId(int commentId)
    {
        return _context.MediaComments
            .Include(comment => comment.MediaFile)
                .ThenInclude(file => file.StorageDevice)
            .AsNoTracking()
            .Where(comment => comment.Id == commentId)
            .Select(comment => comment.MediaFile)
            .FirstOrDefault();
    }

    public IReadOnlyList<MediaType> GetMediaTypes() => Enum.GetValues<MediaType>();

    public bool TryGetMediaType(string rawValue, out MediaType mediaType)
    {
        return Enum.TryParse(rawValue, ignoreCase: true, out mediaType);
    }

    public IReadOnlyList<LocalMediaFile> GetMediaFilesByType(MediaType mediaType) => _context.LocalMediaFiles
        .Include(file => file.Owner)
        .Include(file => file.StorageDevice)
        .AsNoTracking()
        .Where(file => file.MediaType == mediaType)
        .ToList();
}
