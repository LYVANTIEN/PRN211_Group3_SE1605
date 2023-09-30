using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TheaterRepository: ITheaterRepository
    {
        public void DeleteTheater(int theaterId) => TheaterDAO.Instance.Remove(theaterId);


        public Theater GetTheaterById(int theaterId) => TheaterDAO.Instance.GetTheaterById(theaterId);


        public IEnumerable<Theater> GetTheaters() => TheaterDAO.Instance.GetTheaterList();


        public void InsertTheater(Theater theater) => TheaterDAO.Instance.AddNew(theater);


        public void UpdateTheater(Theater theater) => TheaterDAO.Instance.Update(theater);
    }
}
