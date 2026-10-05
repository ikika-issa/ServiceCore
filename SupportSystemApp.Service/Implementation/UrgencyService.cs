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
            throw new NotImplementedException();
        }

        public List<Urgency> GetAll()
        {
            throw new NotImplementedException();
        }

        public Urgency GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Urgency Insert(Urgency urgency)
        {
            throw new NotImplementedException();
        }

        public Urgency Update(Urgency urgency)
        {
            throw new NotImplementedException();
        }
    }
}
