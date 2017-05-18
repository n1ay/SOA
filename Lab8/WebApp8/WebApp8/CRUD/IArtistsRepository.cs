using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp8.Models;


namespace WebApp8.CRUD
{
    public interface IArtistsRepository
    {
        List<Artist> GetAll();
        Artist Get(int id);
        Artist Update(Artist artist);
        bool Delete(int id);
        int Add(Artist artist);
    }
}
