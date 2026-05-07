# Semantic Model

## Entiteti
- AppUser: Id, Username, Email, City, RegisteredAt, IsPremium
- LocalMediaFile: Id, FileName, FilePath, MediaType, SizeInMb, Duration, CreatedAt, AddedAt, IsFavorite, OwnerId, StorageDeviceId
- MediaComment: Id, Text, CreatedAt, IsEdited, AuthorId, MediaFileId
- Playlist: Id, Name, Description, CreatedAt, IsPublic, OwnerId
- Tag: Id, Name, ColorHex
- StorageDevice: Id, Name, CapacityInGb, FreeSpaceInGb, DevicePath, IsExternal
- LocalMediaLibrary: Id, Name, CreatedAt

## Veze
- AppUser 1-N LocalMediaFile (OwnerId)
- AppUser 1-N Playlist (OwnerId)
- AppUser 1-N MediaComment (AuthorId)
- StorageDevice 1-N LocalMediaFile (StorageDeviceId)
- LocalMediaFile 1-N MediaComment (MediaFileId)
- LocalMediaFile N-N Tag
- LocalMediaFile N-N Playlist
- LocalMediaLibrary N-N AppUser
- LocalMediaLibrary N-N Playlist
- LocalMediaLibrary N-N StorageDevice
