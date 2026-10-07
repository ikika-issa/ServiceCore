using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface IPriorityService
    {
        List<TicketPriority> GetAll();
        TicketPriority GetById(Guid id);
        TicketPriority Insert(TicketPriority priority);
        TicketPriority Update(TicketPriority priority);
        TicketPriority DeleteById(Guid id);
    }
}
