using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MusicStoreDb.Services.Models;

namespace MusicStoreDb.Client
{
    internal class ClientMain
    {
        internal static void Main(string[] args)
        {
            HttpRequester requester = new HttpRequester("http://localhost:16099/api/");

            #region ----------------Albums demo----------------
            AlbumModel albumModel = new AlbumModel()
            {
                Producer = "me",
                Title = "title",
                Year = 1555
            };

            // Post album - application/json
            var postResponseJson = requester.Post("albums", albumModel);
            Console.WriteLine(postResponseJson);

            // Post album - application/xml
            var postResponseXml = requester.Post("albums", albumModel, "application/xml");
            Console.WriteLine(postResponseXml);

            // Get album
            var album = requester.Get<AlbumModel>("albums/4");
            PrintAlbum(album);

            // GetAll albums
            var albums = requester.GetAll<AlbumModel>("albums");
            PrintAlbums(albums);

            // Put/Update album - application/json
            var putResponseJson = requester.Put("albums/4",
                new AlbumModel()
                {
                    Producer = "Some producer",
                    Title = "Some title",
                    Year = 2013
                });

            Console.WriteLine(putResponseJson);

            // Put/Update album - application/xml
            var putResponseXml = requester.Put("albums/4",
                new AlbumModel()
                {
                    Producer = "qweqweqwe",
                    Title = "Some title",
                    Year = 2013
                }, "application/xml");

            Console.WriteLine(putResponseXml);

            // Delete album
            var deleteResponse = requester.Delete("albums/4");
            Console.WriteLine(deleteResponse);
            #endregion

            #region ----------------Artists demo----------------
            //ArtistModel artistModel = new ArtistModel()
            //{
            //    Country = "Bulgaria",
            //    DateOfBirth = DateTime.Now,
            //    Name = "Pesho"
            //};

            //// Post artist - application/json
            //var postResponseJson = requester.Post("artists", artistModel);
            //Console.WriteLine(postResponseJson);

            //// Post artist - application/xml
            //var postResponseXml = requester.Post("artists", artistModel, "application/xml");
            //Console.WriteLine(postResponseXml);

            //// Get artist
            //var artist = requester.Get<ArtistModel>("artists/4");
            //PrintArtist(artist);

            //// GetAll artists
            //var artists = requester.GetAll<ArtistModel>("artists");
            //PrintArtists(artists);

            //// Put/Update artist - application/json
            //var putResponseJson = requester.Put("artists/4",
            //    new ArtistModel()
            //    {
            //        Country = "Germany",
            //        DateOfBirth = DateTime.Now.AddDays(30),
            //        Name = "Gosho"
            //    });

            //Console.WriteLine(putResponseJson);

            //// Put/Update artist - application/xml
            //var putResponseXml = requester.Put("artists/4",
            //    new ArtistModel()
            //    {
            //        Country = "Germany",
            //        DateOfBirth = DateTime.Now.AddDays(30),
            //        Name = "Gosho"
            //    }, "application/xml");

            //Console.WriteLine(putResponseXml);

            //// Delete artist
            //var deleteResponse = requester.Delete("artists/4");
            //Console.WriteLine(deleteResponse);
            #endregion

            #region ----------------Songs demo----------------
            //SongModel songModel = new SongModel()
            //{
            //    AlbumId = 4,
            //    ArtistId = 4,
            //    Genre = "Hard Rock",
            //    Title = "Some title",
            //    Year = 1980
            //};

            //// Post song - application/json
            //var postResponseJson = requester.Post("songs", songModel);
            //Console.WriteLine(postResponseJson);

            //// Post song - application/xml
            //var postResponseXml = requester.Post("songs", songModel, "application/xml");
            //Console.WriteLine(postResponseXml);

            //// Get song
            //var song = requester.Get<SongModel>("songs/4");
            //PrintSong(song);

            //// GetAll songs
            //var songs = requester.GetAll<SongModel>("songs");
            //PrintSongs(songs);

            //// Put/Update song - application/json
            //var putResponseJson = requester.Put("songs/4",
            //    new SongModel()
            //    {
            //        AlbumId = 5,
            //        ArtistId = 5,
            //        Genre = "Heavy Metal",
            //        Title = "arhhhhhhhhhhh",
            //        Year = 1980
            //    });

            //Console.WriteLine(putResponseJson);

            //// Put/Update song - application/xml
            //var putResponseXml = requester.Put("songs/4",
            //    new SongModel()
            //    {
            //        AlbumId = 6,
            //        ArtistId = 6,
            //        Genre = "Pop",
            //        Title = "Yeahhhhhhhhhhh",
            //        Year = 1985
            //    }, "application/xml");

            //Console.WriteLine(putResponseXml);

            //// Delete song
            //var deleteResponse = requester.Delete("songs/4");
            //Console.WriteLine(deleteResponse);
            #endregion
        }

        internal static void PrintAlbum(AlbumModel album)
        {
            Console.WriteLine(album.Id);
            Console.WriteLine(album.Title);
            Console.WriteLine(album.Producer);
            Console.WriteLine(album.Year);
        }

        internal static void PrintAlbums(IEnumerable<AlbumModel> albums)
        {
            foreach (var album in albums)
            {
                PrintAlbum(album);
            }
        }

        internal static void PrintArtist(ArtistModel artist)
        {
            Console.WriteLine(artist.Id);
            Console.WriteLine(artist.Name);
            Console.WriteLine(artist.Country);
            Console.WriteLine(artist.DateOfBirth);
        }

        internal static void PrintArtists(IEnumerable<ArtistModel> artists)
        {
            foreach (var artist in artists)
            {
                PrintArtist(artist);
            }
        }

        internal static void PrintSong(SongModel song)
        {
            Console.WriteLine(song.Id);
            Console.WriteLine(song.Title);
            Console.WriteLine(song.Year);
            Console.WriteLine(song.Genre);
            Console.WriteLine(song.AlbumId);
            Console.WriteLine(song.ArtistId);
        }

        internal static void PrintSongs(IEnumerable<SongModel> songs)
        {
            foreach (var song in songs)
            {
                PrintSong(song);
            }
        }
    }
}
