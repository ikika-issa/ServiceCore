using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class PriorityService : IPriorityService
    {
        private readonly IRepository<TicketPriority> _priorityRepository;

        public PriorityService(IRepository<TicketPriority> priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }


        public TicketPriority DeleteById(Guid id)
        {
            var priority = _priorityRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id));

            if (priority == null)
            {
                throw new Exception($"Priority with id {id} not found.");
            }

            _priorityRepository.Delete(priority);
            return priority;
        }

        public List<TicketPriority> GetAll()
        {
            return _priorityRepository.GetAll(selector: x => x).ToList();
        }

        public TicketPriority GetById(Guid id)
        {
            return _priorityRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id))!;
        }

        public TicketPriority Insert(TicketPriority priority)
        {
            priority.Id = Guid.NewGuid();
            return _priorityRepository.Insert(priority);
        }

        public TicketPriority Update(TicketPriority priority)
        {
            return _priorityRepository.Update(priority);
        }
    }
}
