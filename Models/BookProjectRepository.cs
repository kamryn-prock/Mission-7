using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Models
{
    public class BookProjectRepository
    {
        public interface IBookProjectRepository
        {
            //Class set up specificably for querying data
            //only set a get meaning we can read but not write data
            IQueryable<Book> Books { get; }
        }
    }
}
