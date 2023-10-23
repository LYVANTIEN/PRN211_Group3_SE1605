using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.Repository
{
    public interface ITheaterRepository
    {
        IEnumerable<Theater> GetTheaters();
        Theater GetTheaterById(int theaterId);
        void InsertTheater(Theater theater);
        void UpdateTheater(Theater theater);
        void DeleteTheater(int theaterId);
    }
}
