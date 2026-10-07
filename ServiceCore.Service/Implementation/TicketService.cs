using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SupportSystemApp.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket DeleteById(Guid id)
        {
            var ticket = _ticketRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (ticket == null)
            {
                throw new Exception($"Ticket with id {id} not found.");
            }

            _ticketRepository.Delete(ticket);
            return ticket;
        }

        public List<Ticket> GetAll()
        {
            return _ticketRepository.GetAll(selector: x => x, 
                include: x => x
                .Include(t => t.OpenedBy)
                .Include(t => t.AssignedTo)
                .Include(t => t.Site)
                .Include(t => t.SupportGroup)
                .Include(t => t.Notes)
                .Include(t => t.TicketTasks)
                ).ToList();
        }

        public Ticket GetById(Guid id)
        {
            return _ticketRepository.Get(selector: x => x, predicate: x => x.Id == id,
                include: x => x
                .Include(t => t.OpenedBy)
                .Include(t => t.AssignedTo)
                .Include(t => t.Site)
                .Include(t => t.SupportGroup)
                .Include(t => t.Notes)
                .Include(t => t.TicketTasks));
        }

        public Ticket Insert(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid();
            ticket.TicketNumber = GenerateTicketNumber();
            ticket.CreatedAt = DateTime.UtcNow; //CHECK LATER
            return _ticketRepository.Insert(ticket);
        }

        public string GenerateTicketNumber()
        {
            var lastTicket = _ticketRepository
                .GetAll(selector: x => x)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();

            int nextNumber = 1;

            if (lastTicket != null && !string.IsNullOrEmpty(lastTicket.TicketNumber))
            {
                // Ako brojot e primer "TKT-000123"
                string numericPart = lastTicket.TicketNumber.Replace("TKT-", "");

                if (int.TryParse(numericPart, out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"TKT-{nextNumber:D6}";
        }

        public Ticket Update(Ticket ticket)
        {
            return _ticketRepository.Update(ticket);
        }
    }
}
