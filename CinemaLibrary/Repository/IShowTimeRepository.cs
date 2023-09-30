using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IShowTimeRepository
    {
        IEnumerable<ShowTime> GetShowTimes();
        ShowTime GetShowTimesById(int timeId);

        void Insert(ShowTime showTime);
        void Update(ShowTime showTime);
        void Delete(int timeId);
    }
}
