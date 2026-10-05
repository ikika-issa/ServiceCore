using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface IStatusService
    {
        List<TicketStatus> GetAll();
        TicketStatus GetById(Guid id);
        TicketStatus Insert(TicketStatus status);
        TicketStatus Update(TicketStatus status);
        TicketStatus DeleteById(Guid id);
    }
}
