using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp8.Models;
using LiteDB;
using Npgsql;

namespace WebApp8.CRUD
{
    public class PaintingsRepository : IPaintingsRepository
    {
        public static readonly int NoSQL = 0;
        public static readonly int PostgreSQL = 1;
        private int Type;

        public PaintingsRepository(int type = 0)
        {
            Type = type;
        }

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(Config.PaintingsDBPath))
            {
                var collection = db.GetCollection<PaintingDB>("paintings");
                if (collection.FindById(painting.Id) == null)
                    collection.Insert(InverseMap(painting));
                else
                    collection.Update(InverseMap(painting));
                return painting.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(Config.PaintingsDBPath))
            {
                var collection = db.GetCollection<PaintingDB>("paintings");
                return collection.Delete(id);
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(Config.PaintingsDBPath))
            {
                var collection = db.GetCollection<PaintingDB>("paintings");
                return Map(collection.FindById(id));
            }
        }

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(Config.PaintingsDBPath))
            {
                var collection = db.GetCollection<PaintingDB>("paintings");
                return collection.FindAll().Select(x => Map(x)).ToList();
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(Config.PaintingsDBPath))
            {
                var colletion = db.GetCollection<PaintingDB>("paintings");
                if (colletion.Update(InverseMap(painting)))
                    return painting;
                else
                    return null;
            }
        }

        Painting Map(PaintingDB painting)
        {
            if (painting == null)
                return null;
            Painting result = new Painting() { Id = painting.Id, Title = painting.Title, Year = painting.Year };
            return result;
        }

        PaintingDB InverseMap(Painting painting)
        {
            if (painting == null)
                return null;
            PaintingDB result = new PaintingDB() { Id = painting.Id, Title = painting.Title, Year = painting.Year };
            return result;
        }
    }
}