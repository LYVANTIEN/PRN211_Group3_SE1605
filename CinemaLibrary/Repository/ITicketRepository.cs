using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        Ticket GetTicketbyID(int ticketID);
        void InsertTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int ticketID);
    }
}
