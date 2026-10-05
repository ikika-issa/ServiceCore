using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IRepository<TicketStatus> _statusRepository;

        public StatusService(IRepository<TicketStatus> statusRepository)
        {
            _statusRepository = statusRepository;
        }


        public TicketStatus DeleteById(Guid id)
        {
            var status = _statusRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (status == null)
            {
                throw new Exception($"TicketStatus with Id {id} not found.");
            }

            _statusRepository.Delete(status);
            return status;
        }

        public List<TicketStatus> GetAll()
        {
            return _statusRepository.GetAll(selector: x => x).ToList();
        }

        public TicketStatus GetById(Guid id)
        {
            return _statusRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public TicketStatus Insert(TicketStatus status)
        {
            status.Id = Guid.NewGuid();
            return _statusRepository.Insert(status);
        }

        public TicketStatus Update(TicketStatus status)
        {
            return _statusRepository.Update(status);
        }
    }
}
