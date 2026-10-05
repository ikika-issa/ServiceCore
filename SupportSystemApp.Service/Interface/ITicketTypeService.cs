using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ITicketTypeService
    {
        List<TicketType> GetAll();
        TicketType GetById(Guid id);
        TicketType Insert(TicketType ticketType);
        TicketType Update(TicketType ticketType);
        TicketType DeleteById(Guid id);
    }
}
