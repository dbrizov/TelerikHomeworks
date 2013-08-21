using System;
using System.Linq;
using System.Runtime.Serialization;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Services.Models
{
    [DataContract(Name="songModel")]
    public class SongModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "genre")]
        public string Genre { get; set; }

        [DataMember(Name = "artistId")]
        public int ArtistId { get; set; }

        [DataMember(Name = "albumId")]
        public int AlbumId { get; set; }

        public static SongModel CreateFromSongEntity(Song entity)
        {
            return new SongModel()
            {
                Id = entity.SongId,
                Title = entity.Title,
                Year = entity.Year,
                Genre = entity.Genre,
                ArtistId = entity.ArtistId,
                AlbumId = entity.AlbumId
            };
        }
    }
}