using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IAuthorRepository
    {
        int Add(Author author);
        Author Update(Author author);
        List<Author> GetAll();
        Author Get(int id);
        bool Delete(int id);
    }
}
