using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp8.Models;
using LiteDB;
using Npgsql;
using Dapper;

namespace WebApp8.CRUD
{
    public class ArtistRepository : IArtistsRepository
    {
        private readonly string ConnectionString = "Server=127.0.0.1;User Id=postgres;Password=postgres1234;Database=testDatabase2;";
        public static readonly int NoSQL = 0;
        public static readonly int PostgreSQL = 1;
        private int Type;

        public ArtistRepository()
        {
            Type = 1;
        }

        public ArtistRepository(int type)
        {
            Type = type;
        }
        
        public int Add(Artist artist)
        {
            if (Type == 0)
            {
                using (var db = new LiteDatabase(Config.ArtistsDBPath))
                {
                    var collection = db.GetCollection<ArtistDB>("artists");
                    if (collection.FindById(artist.Id) == null)
                        collection.Insert(InverseMap(artist));
                    else
                        collection.Update(InverseMap(artist));
                }
            }
            else
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    var status = connection.Execute("INSERT INTO public.\"Artists\" VALUES(@ID, @ArtistName, @ArtistSurname)", new { artist.Id, artist.ArtistName, artist.ArtistSurname });
                    if (status > 0)
                        return artist.Id;
                    else
                        return -1;
                }
            }
            return artist.Id;
        }

        public bool Delete(int id)
        {
            if (Type == 0)
            {
                using (var db = new LiteDatabase(Config.ArtistsDBPath))
                {
                    var collection = db.GetCollection<ArtistDB>("artists");
                    return collection.Delete(id);
                }
            }
            else
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    var status = connection.Execute("DELETE FROM public.\"Artists\" WHERE \"Id\"=@ID", new { id });
                    if (status > 0)
                        return true;
                    return false;
                }
            }
        }

        public Artist Get(int id)
        {
            if (Type == 0)
            {
                using (var db = new LiteDatabase(Config.ArtistsDBPath))
                {
                    var collection = db.GetCollection<ArtistDB>("artists");
                    return Map(collection.FindById(id));
                }
            }
            else
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    return connection.Query<Artist>("SELECT * FROM public.\"Artists\" WHERE \"Id\"=@ID", new { id }).AsList().ElementAt(0);               
                }
            }
        }

        public List<Artist> GetAll()
        {
            if (Type == 0)
            {
                using (var db = new LiteDatabase(Config.ArtistsDBPath))
                {
                    var collection = db.GetCollection<ArtistDB>("artists");
                    return collection.FindAll().Select(x => Map(x)).ToList();
                }
            }
            else
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    return connection.Query<Artist>("SELECT * FROM public.\"Artists\"").AsList();
                }
            }

        }

        public Artist Update(Artist artist)
        {
            if (Type == 0)
            {
                using (var db = new LiteDatabase(Config.ArtistsDBPath))
                {
                    var colletion = db.GetCollection<ArtistDB>("artists");
                    if (colletion.Update(InverseMap(artist)))
                        return artist;
                    else
                        return null;
                }
            }
            else
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    int status = connection.Execute("UPDATE public.\"Artists\" SET \"Id\" = @ID, \"ArtistName\" = @ArtistName, \"ArtistSurname\" = @ArtistSurname WHERE \"Id\" = @ID", new { artist.Id, artist.ArtistName, artist.ArtistSurname });
                    if (status > 0)
                        return artist;
                    return null;
                }
            }
        }

        Artist Map(ArtistDB artist)
        {
            if (artist == null)
                return null;
            Artist result = new Artist() { Id = artist.Id, ArtistName = artist.ArtistName, ArtistSurname = artist.ArtistSurname };
            return result;
        }

        ArtistDB InverseMap(Artist artist)
        {
            if (artist == null)
                return null;
            ArtistDB result = new ArtistDB() { Id = artist.Id, ArtistName = artist.ArtistName, ArtistSurname = artist.ArtistSurname };
            return result;
        }
    }
}