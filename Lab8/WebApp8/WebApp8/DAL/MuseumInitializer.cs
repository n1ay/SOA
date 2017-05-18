using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp8.Models;

namespace WebApp8.DAL
{
    public class MuseumInitializer: DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var artists = new List<Artist>
            {
                new Artist() {Id = 1, ArtistName = "Kisha", ArtistSurname = "lel"},
                new Artist() {Id = 2, ArtistName = "50Pounds", ArtistSurname = "fuk"}
            };
            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();

            var paintings = new List<Painting>
            {
                new Painting() { Id = 1, Title = "Monalisa", Year = 1444 },
                new Painting() { Id = 2, Title = "Bitwa pod Grunwaldem", Year = 1900 }
            };
            paintings.ForEach(a => context.Paintings.Add(a));
            context.SaveChanges();
        }
    }
}