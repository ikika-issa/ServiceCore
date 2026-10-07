using SupportSystemApp.Domain.Domain_Models;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketModeService : ITicketModeService
    {
        private readonly IRepository<TicketMode> _ticketModeRepository;

        public TicketModeService(IRepository<TicketMode> ticketModeRepository)
        {
            _ticketModeRepository = ticketModeRepository;
        }


        public TicketMode DeleteById(Guid id)
        {
            var ticketMode = _ticketModeRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (ticketMode == null)
            {
                throw new Exception($"TicketMode with Id {id} not found.");
            }

            _ticketModeRepository.Delete(ticketMode);
            return ticketMode;
        }

        public List<TicketMode> GetAll()
        {
            return _ticketModeRepository.GetAll(selector: x => x).ToList();
        }

        public TicketMode GetById(Guid id)
        {
            return _ticketModeRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public TicketMode Insert(TicketMode ticketMode)
        {
            ticketMode.Id = Guid.NewGuid();
            return _ticketModeRepository.Insert(ticketMode);
        }

        public TicketMode Update(TicketMode ticketMode)
        {
            return _ticketModeRepository.Update(ticketMode);
        }
    }
}
