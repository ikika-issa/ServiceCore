using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ITicketModeService
    {
        List<TicketMode> GetAll();
        TicketMode GetById(Guid id);
        TicketMode Insert(TicketMode ticketMode);
        TicketMode Update(TicketMode ticketMode);
        TicketMode DeleteById(Guid id);
    }
}
