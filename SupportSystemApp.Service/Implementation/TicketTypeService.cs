using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IRepository<TicketType> _ticketTypeRepository;

        public TicketTypeService(IRepository<TicketType> ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
        }

        public TicketType DeleteById(Guid id)
        {
            var ticketType = _ticketTypeRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id));

            if(ticketType == null)
            {
                throw new Exception($"TicketType with Id {id} not found.");
            }

            _ticketTypeRepository.Delete(ticketType);
            return ticketType;
        }

        public List<TicketType> GetAll()
        {
            return _ticketTypeRepository.GetAll(selector: x => x).ToList();
        }

        public TicketType GetById(Guid id)
        {
            return _ticketTypeRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id))!;
        }

        public TicketType Insert(TicketType ticketType)
        {
            ticketType.Id = Guid.NewGuid();
            return _ticketTypeRepository.Insert(ticketType);
        }

        public TicketType Update(TicketType ticketType)
        {
            return _ticketTypeRepository.Update(ticketType);
        }
    }
}
