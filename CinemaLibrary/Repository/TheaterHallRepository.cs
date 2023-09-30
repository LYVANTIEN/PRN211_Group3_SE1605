using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TheaterHallRepository: ITheaterHallRepository
    {
        public void Delete(int theaterHallId)
        {
            TheaterHallDAO.Instance.Remove(theaterHallId);
        }

        public IEnumerable<TheaterHall> GetTheaterHalls()
        {
            return TheaterHallDAO.Instance.GetList();
        }

        public TheaterHall GetTheaterHallById(int theaterHallId)
        {
            return TheaterHallDAO.Instance.GetTheatreHallById(theaterHallId);
        }

        public void Insert(TheaterHall theaterHall)
        {
            TheaterHallDAO.Instance.AddNew(theaterHall);
        }

        public void Update(TheaterHall theaterHall)
        {
            TheaterHallDAO.Instance.Update(theaterHall);
        }
    }
}
