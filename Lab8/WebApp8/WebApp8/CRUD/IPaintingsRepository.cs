using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp8.Models;

namespace WebApp8.CRUD
{
    public interface IPaintingsRepository
    {
        List<Painting> GetAll();
        Painting Get(int id);
        Painting Update(Painting painting);
        bool Delete(int id);
        int Add(Painting painting);
    }
}
