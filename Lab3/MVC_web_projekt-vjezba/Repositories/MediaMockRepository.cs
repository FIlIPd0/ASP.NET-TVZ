using MVC_web_projekt_vjezba.Models;

namespace MVC_web_projekt_vjezba.Repositories;

public class MediaMockRepository
{
    private readonly List<AppUser> _users;
    private readonly List<Tag> _tags;
    private readonly List<StorageDevice> _storageDevices;
    private readonly List<LocalMediaFile> _mediaFiles;
    private readonly List<Playlist> _playlists;
    private readonly List<LocalMediaLibrary> _libraries;
    private readonly List<MediaComment> _comments;

    public MediaMockRepository()
    {
        _users = CreateUsers();
        _tags = CreateTags();
        _storageDevices = CreateStorageDevices();
        _mediaFiles = CreateMediaFiles(_users, _tags, _storageDevices);
        _playlists = CreatePlaylists(_users, _mediaFiles);
        ConnectPlaylistRelations(_playlists);
        _libraries = CreateLibraries(_users, _playlists, _storageDevices);
        _comments = _mediaFiles
            .SelectMany(file => file.Comments)
            .OrderByDescending(comment => comment.CreatedAt)
            .ToList();
    }

    public IReadOnlyList<AppUser> GetUsers() => _users;

    public AppUser? GetUserById(int id) => _users.FirstOrDefault(user => user.Id == id);

    public IReadOnlyList<Tag> GetTags() => _tags;

    public Tag? GetTagById(int id) => _tags.FirstOrDefault(tag => tag.Id == id);

    public IReadOnlyList<StorageDevice> GetStorageDevices() => _storageDevices;

    public StorageDevice? GetStorageDeviceById(int id) => _storageDevices.FirstOrDefault(device => device.Id == id);

    public IReadOnlyList<LocalMediaFile> GetMediaFiles() => _mediaFiles;

    public LocalMediaFile? GetMediaFileById(int id) => _mediaFiles.FirstOrDefault(file => file.Id == id);

    public IReadOnlyList<Playlist> GetPlaylists() => _playlists;

    public Playlist? GetPlaylistById(int id) => _playlists.FirstOrDefault(playlist => playlist.Id == id);

    public IReadOnlyList<LocalMediaLibrary> GetLibraries() => _libraries;

    public LocalMediaLibrary? GetLibraryById(int id) => _libraries.FirstOrDefault(library => library.Id == id);

    public IReadOnlyList<MediaComment> GetComments() => _comments;

    public MediaComment? GetCommentById(int id) => _comments.FirstOrDefault(comment => comment.Id == id);

    public LocalMediaFile? GetFileByCommentId(int commentId)
    {
        return _mediaFiles.FirstOrDefault(file => file.Comments.Any(comment => comment.Id == commentId));
    }

    public IReadOnlyList<MediaType> GetMediaTypes() => Enum.GetValues<MediaType>();

    public bool TryGetMediaType(string rawValue, out MediaType mediaType)
    {
        return Enum.TryParse(rawValue, ignoreCase: true, out mediaType);
    }

    public IReadOnlyList<LocalMediaFile> GetMediaFilesByType(MediaType mediaType)
    {
        return _mediaFiles.Where(file => file.MediaType == mediaType).ToList();
    }

    private static List<AppUser> CreateUsers()
    {
        return
        [
            new AppUser
            {
                Id = 1,
                Username = "ana",
                Email = "ana@lokalno.hr",
                City = "Zagreb",
                RegisteredAt = new DateTime(2025, 5, 10),
                IsPremium = true
            },
            new AppUser
            {
                Id = 2,
                Username = "marko",
                Email = "marko@lokalno.hr",
                City = "Split",
                RegisteredAt = new DateTime(2025, 7, 3),
                IsPremium = false
            },
            new AppUser
            {
                Id = 3,
                Username = "ivana",
                Email = "ivana@lokalno.hr",
                City = "Rijeka",
                RegisteredAt = new DateTime(2026, 1, 15),
                IsPremium = false
            },
            new AppUser
            {
                Id = 4,
                Username = "luka",
                Email = "luka@lokalno.hr",
                City = "Osijek",
                RegisteredAt = new DateTime(2026, 2, 20),
                IsPremium = true
            }
        ];
    }

    private static List<Tag> CreateTags()
    {
        return
        [
            new Tag { Id = 1, Name = "obitelj", ColorHex = "#C85D3A" },
            new Tag { Id = 2, Name = "putovanje", ColorHex = "#0F7C82" },
            new Tag { Id = 3, Name = "posao", ColorHex = "#3C6E71" },
            new Tag { Id = 4, Name = "muzika", ColorHex = "#A77722" },
            new Tag { Id = 5, Name = "backup", ColorHex = "#4B5D67" }
        ];
    }

    private static List<StorageDevice> CreateStorageDevices()
    {
        return
        [
            new StorageDevice
            {
                Id = 1,
                Name = "SSD-C",
                CapacityInGb = 1000,
                FreeSpaceInGb = 420,
                DevicePath = "C:/",
                IsExternal = false
            },
            new StorageDevice
            {
                Id = 2,
                Name = "USB-Backup",
                CapacityInGb = 256,
                FreeSpaceInGb = 150,
                DevicePath = "E:/",
                IsExternal = true
            },
            new StorageDevice
            {
                Id = 3,
                Name = "NAS-Home",
                CapacityInGb = 4000,
                FreeSpaceInGb = 2100,
                DevicePath = "//nas/home",
                IsExternal = true
            },
            new StorageDevice
            {
                Id = 4,
                Name = "Archive-HDD",
                CapacityInGb = 2000,
                FreeSpaceInGb = 300,
                DevicePath = "F:/",
                IsExternal = true
            }
        ];
    }

    private static List<LocalMediaFile> CreateMediaFiles(List<AppUser> users, List<Tag> tags, List<StorageDevice> devices)
    {
        var media = new List<LocalMediaFile>
        {
            new()
            {
                Id = 1,
                FileName = "more-2025.mp4",
                FilePath = "/media/video/more-2025.mp4",
                MediaType = MediaType.Video,
                SizeInMb = 850,
                Duration = TimeSpan.FromMinutes(7),
                CreatedAt = new DateTime(2025, 8, 12),
                AddedAt = new DateTime(2025, 8, 13),
                IsFavorite = true,
                Owner = users[0],
                StorageDevice = devices[0]
            },
            new()
            {
                Id = 2,
                FileName = "koncert.mp3",
                FilePath = "/media/audio/koncert.mp3",
                MediaType = MediaType.Audio,
                SizeInMb = 11,
                Duration = TimeSpan.FromMinutes(4),
                CreatedAt = new DateTime(2025, 9, 1),
                AddedAt = new DateTime(2025, 9, 1),
                IsFavorite = false,
                Owner = users[0],
                StorageDevice = devices[1]
            },
            new()
            {
                Id = 3,
                FileName = "racun.pdf",
                FilePath = "/documents/racun.pdf",
                MediaType = MediaType.Document,
                SizeInMb = 2,
                Duration = TimeSpan.Zero,
                CreatedAt = new DateTime(2026, 2, 2),
                AddedAt = new DateTime(2026, 2, 2),
                IsFavorite = false,
                Owner = users[1],
                StorageDevice = devices[1]
            },
            new()
            {
                Id = 4,
                FileName = "drone-shot.mp4",
                FilePath = "/nas/home/video/drone-shot.mp4",
                MediaType = MediaType.Video,
                SizeInMb = 1200,
                Duration = TimeSpan.FromMinutes(12),
                CreatedAt = new DateTime(2025, 11, 5),
                AddedAt = new DateTime(2025, 11, 6),
                IsFavorite = true,
                Owner = users[1],
                StorageDevice = devices[2]
            },
            new()
            {
                Id = 5,
                FileName = "portret.jpg",
                FilePath = "/media/images/portret.jpg",
                MediaType = MediaType.Image,
                SizeInMb = 6,
                Duration = TimeSpan.Zero,
                CreatedAt = new DateTime(2026, 1, 20),
                AddedAt = new DateTime(2026, 1, 21),
                IsFavorite = false,
                Owner = users[2],
                StorageDevice = devices[0]
            },
            new()
            {
                Id = 6,
                FileName = "predavanje.mp4",
                FilePath = "/nas/home/video/predavanje.mp4",
                MediaType = MediaType.Video,
                SizeInMb = 640,
                Duration = TimeSpan.FromMinutes(20),
                CreatedAt = new DateTime(2026, 3, 7),
                AddedAt = new DateTime(2026, 3, 7),
                IsFavorite = true,
                Owner = users[2],
                StorageDevice = devices[2]
            },
            new()
            {
                Id = 7,
                FileName = "sastanak.wav",
                FilePath = "/audio/sastanak.wav",
                MediaType = MediaType.Audio,
                SizeInMb = 52,
                Duration = TimeSpan.FromMinutes(30),
                CreatedAt = new DateTime(2026, 3, 10),
                AddedAt = new DateTime(2026, 3, 10),
                IsFavorite = false,
                Owner = users[0],
                StorageDevice = devices[1]
            },
            new()
            {
                Id = 8,
                FileName = "plan.xlsx",
                FilePath = "/documents/plan.xlsx",
                MediaType = MediaType.Document,
                SizeInMb = 4,
                Duration = TimeSpan.Zero,
                CreatedAt = new DateTime(2026, 2, 15),
                AddedAt = new DateTime(2026, 2, 15),
                IsFavorite = false,
                Owner = users[1],
                StorageDevice = devices[0]
            },
            new()
            {
                Id = 9,
                FileName = "vikend.mp4",
                FilePath = "/media/video/vikend.mp4",
                MediaType = MediaType.Video,
                SizeInMb = 780,
                Duration = TimeSpan.FromMinutes(9),
                CreatedAt = new DateTime(2026, 4, 1),
                AddedAt = new DateTime(2026, 4, 2),
                IsFavorite = true,
                Owner = users[2],
                StorageDevice = devices[0]
            },
            new()
            {
                Id = 10,
                FileName = "scan-ugovor.pdf",
                FilePath = "/documents/contracts/scan-ugovor.pdf",
                MediaType = MediaType.Document,
                SizeInMb = 12,
                Duration = TimeSpan.Zero,
                CreatedAt = new DateTime(2026, 3, 31),
                AddedAt = new DateTime(2026, 4, 1),
                IsFavorite = false,
                Owner = users[3],
                StorageDevice = devices[3]
            }
        };

        foreach (var item in media)
        {
            item.Owner.UploadedFiles.Add(item);
            item.StorageDevice.MediaFiles.Add(item);
        }

        AddTag(media[0], tags[1]);
        AddTag(media[0], tags[0]);
        AddTag(media[1], tags[3]);
        AddTag(media[2], tags[2]);
        AddTag(media[3], tags[1]);
        AddTag(media[4], tags[0]);
        AddTag(media[5], tags[2]);
        AddTag(media[6], tags[2]);
        AddTag(media[7], tags[2]);
        AddTag(media[8], tags[1]);
        AddTag(media[9], tags[4]);

        media[0].Comments.Add(new MediaComment
        {
            Id = 1,
            Text = "Odlican kadar.",
            CreatedAt = new DateTime(2025, 8, 14),
            IsEdited = false,
            Author = users[1]
        });

        media[0].Comments.Add(new MediaComment
        {
            Id = 2,
            Text = "Treba napraviti backup.",
            CreatedAt = new DateTime(2025, 8, 15),
            IsEdited = true,
            Author = users[2]
        });

        media[3].Comments.Add(new MediaComment
        {
            Id = 3,
            Text = "Clip je odlican za promo.",
            CreatedAt = new DateTime(2025, 11, 7),
            IsEdited = false,
            Author = users[0]
        });

        media[5].Comments.Add(new MediaComment
        {
            Id = 4,
            Text = "Dodaj titlove prije dijeljenja.",
            CreatedAt = new DateTime(2026, 3, 8),
            IsEdited = false,
            Author = users[3]
        });

        media[9].Comments.Add(new MediaComment
        {
            Id = 5,
            Text = "Potpis vidljiv, sve OK.",
            CreatedAt = new DateTime(2026, 4, 1),
            IsEdited = false,
            Author = users[1]
        });

        return media;
    }

    private static List<Playlist> CreatePlaylists(List<AppUser> users, List<LocalMediaFile> media)
    {
        var playlists = new List<Playlist>
        {
            new()
            {
                Id = 1,
                Name = "Ljeto 2025",
                Description = "Video i slike s mora",
                CreatedAt = new DateTime(2025, 8, 20),
                IsPublic = true,
                Owner = users[0],
                MediaFiles = new List<LocalMediaFile> { media[0], media[4], media[8] }
            },
            new()
            {
                Id = 2,
                Name = "Posao",
                Description = "Dokumenti i snimke za posao",
                CreatedAt = new DateTime(2026, 2, 20),
                IsPublic = false,
                Owner = users[1],
                MediaFiles = new List<LocalMediaFile> { media[2], media[7], media[6], media[9] }
            },
            new()
            {
                Id = 3,
                Name = "Video kolekcija",
                Description = "Najbolji video zapisi",
                CreatedAt = new DateTime(2026, 4, 5),
                IsPublic = true,
                Owner = users[2],
                MediaFiles = new List<LocalMediaFile> { media[3], media[5], media[8] }
            },
            new()
            {
                Id = 4,
                Name = "Za klijenta",
                Description = "Dokumenti i preview materijali",
                CreatedAt = new DateTime(2026, 4, 10),
                IsPublic = false,
                Owner = users[3],
                MediaFiles = new List<LocalMediaFile> { media[9], media[1], media[4] }
            }
        };

        foreach (var playlist in playlists)
        {
            playlist.Owner.Playlists.Add(playlist);
        }

        return playlists;
    }

    private static List<LocalMediaLibrary> CreateLibraries(
        IReadOnlyList<AppUser> users,
        IReadOnlyList<Playlist> playlists,
        IReadOnlyList<StorageDevice> devices)
    {
        return
        [
            new LocalMediaLibrary
            {
                Id = 1,
                Name = "Studio Main",
                CreatedAt = new DateTime(2025, 5, 1),
                Users = users.Take(3).ToList(),
                Playlists = playlists.Take(3).ToList(),
                StorageDevices = devices.Take(3).ToList()
            },
            new LocalMediaLibrary
            {
                Id = 2,
                Name = "Portable Archive",
                CreatedAt = new DateTime(2026, 3, 20),
                Users = users.Skip(1).ToList(),
                Playlists = playlists.Skip(1).ToList(),
                StorageDevices = devices.Skip(1).ToList()
            }
        ];
    }

    private static void ConnectPlaylistRelations(IEnumerable<Playlist> playlists)
    {
        foreach (var playlist in playlists)
        {
            foreach (var media in playlist.MediaFiles)
            {
                media.Playlists.Add(playlist);
            }
        }
    }

    private static void AddTag(LocalMediaFile media, Tag tag)
    {
        media.Tags.Add(tag);
        tag.MediaFiles.Add(media);
    }
}
