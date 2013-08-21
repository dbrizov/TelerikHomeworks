using System;
using System.Linq;
using System.Runtime.Serialization;
using MusicStoreDb.DataLayer;

namespace MusicStoreDb.Services.Models
{
    [DataContract(Name="artistModel")]
    public class ArtistModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "dateOfBirth")]
        public System.DateTime DateOfBirth { get; set; }

        public static ArtistModel CreateFromArtistEntity(Artist entity)
        {
            return new ArtistModel()
            {
                Id = entity.ArtistsId,
                Name = entity.Name,
                Country = entity.Country,
                DateOfBirth = entity.DateOfBirth
            };
        }
    }
}