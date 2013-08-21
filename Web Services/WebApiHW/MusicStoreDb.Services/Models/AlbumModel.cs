using System;
using System.Linq;
using System.Runtime.Serialization;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Services.Models
{
    [DataContract(Name="albumModel")]
    public class AlbumModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="year")]
        public int Year { get; set; }

        [DataMember(Name="producer")]
        public string Producer { get; set; }

        public static AlbumModel CreateFromAlbumEntity(Album entity)
        {
            AlbumModel model = new AlbumModel()
            {
                Id = entity.AlbumId,
                Title = entity.Title,
                Producer = entity.Producer,
                Year = entity.Year
            };

            return model;
        }
    }
}