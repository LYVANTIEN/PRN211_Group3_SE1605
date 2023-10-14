using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.Repository
{
    public interface ITheaterHallRepository
    {
        IEnumerable<TheaterHall> GetTheaterHalls();
        TheaterHall GetTheaterHallById(int theaterHallId);
        void Insert(TheaterHall theaterHall);
        void Update(TheaterHall theaterHall);
        void Delete(int theaterHallId);
    }
}
