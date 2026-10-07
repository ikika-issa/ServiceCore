using SupportSystemApp.Domain.Domain_Models;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class UrgencyService : IUrgencyService
    {
        private readonly IRepository<Urgency> _urgencyRepository;

        public UrgencyService(IRepository<Urgency> urgencyRepository)
        {
            _urgencyRepository = urgencyRepository;
        }

        public Urgency DeleteById(Guid id)
        {
            var urgency = GetById(id);

            if(urgency == null)
            {
                throw new Exception("Urgency not found");
            }
            
            _urgencyRepository.Delete(urgency);
            return urgency;
        }

        public List<Urgency> GetAll()
        {
            return _urgencyRepository.GetAll(selector: x => x).ToList();
        }

        public Urgency GetById(Guid id)
        {
            return _urgencyRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Urgency Insert(Urgency urgency)
        {
            urgency.Id = Guid.NewGuid();
            return _urgencyRepository.Insert(urgency);
        }

        public Urgency Update(Urgency urgency)
        {
            return _urgencyRepository.Update(urgency);
        }
    }
}
