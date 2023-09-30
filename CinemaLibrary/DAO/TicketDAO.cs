using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public  class TicketDAO
    {
        private static TicketDAO instance = null;
        private static readonly object instanceLock = new object();
        public static TicketDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TicketDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Ticket> GetTicketList()
        {
            var tickets = new List<Ticket>();
            try
            {
                using var context = new CinemaDbContext();
                tickets = context.Ticket.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tickets;
        }

        public Ticket GetTicketbyID(int ticketID)
        {
            Ticket ticket = null;
            try
            {
                using var context = new CinemaDbContext();
                ticket = context.Ticket.SingleOrDefault(c => c.TicketId == ticketID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ticket;

        }

        public void AddNew(Ticket ticket)
        {
            try
            {
                Ticket _ticket = GetTicketbyID(ticket.TicketId);
                if (_ticket == null)
                {
                    using var context = new CinemaDbContext();
                    context.Ticket.Add(ticket);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The ticket is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Ticket ticket)
        {
            try
            {
                Ticket _ticket = GetTicketbyID(ticket.TicketId);
                if (_ticket != null)
                {
                    using var context = new CinemaDbContext();
                    context.Ticket.Update(ticket);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The ticket does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int ticketID)
        {
            try
            {
                Ticket ticket = GetTicketbyID(ticketID);
                if (ticket != null)
                {
                    using var context = new CinemaDbContext();
                    context.Ticket.Remove(ticket);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("the ticket does not already exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
