using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IBookRepository
    {
        int Add(Book book);
        Book Update(Book book);
        List<Book> GetAll();
        Book Get(int id);
        bool Delete(int id);
    }
}
