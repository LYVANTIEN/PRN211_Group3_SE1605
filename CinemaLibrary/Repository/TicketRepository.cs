using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TicketRepository: ITicketRepository
    {
        public void DeleteTicket(int ticketID) => TicketDAO.Instance.Remove(ticketID);

        public Ticket GetTicketbyID(int ticketID) => TicketDAO.Instance.GetTicketbyID(ticketID);


        public IEnumerable<Ticket> GetTickets() => TicketDAO.Instance.GetTicketList();


        public void InsertTicket(Ticket ticket) => TicketDAO.Instance.AddNew(ticket);


        public void UpdateTicket(Ticket ticket) => TicketDAO.Instance.Update(ticket);
    }
}
