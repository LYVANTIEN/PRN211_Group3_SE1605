using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ShowTimeRepository
    {
        public void Delete(int timeId)
        {
            ShowTimeDAO.Instance.Remove(timeId);
        }

        public IEnumerable<ShowTime> GetShowTimes()
        {
            return ShowTimeDAO.Instance.GetShowTimeList();
        }

        public ShowTime GetShowTimesById(int timeId)
        {
            return ShowTimeDAO.Instance.GetShowTimeByID(timeId);
        }

        public void Insert(ShowTime showTime)
        {
            ShowTimeDAO.Instance.AddNew(showTime);
        }

        public void Update(ShowTime showTime)
        {
            ShowTimeDAO.Instance.Update(showTime);
        }
    }
}
