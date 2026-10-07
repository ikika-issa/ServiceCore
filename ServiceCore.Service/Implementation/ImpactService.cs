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
    public class ImpactService : IImpactService
    {
        private readonly IRepository<Impact> _impactRepository;

        public ImpactService(IRepository<Impact> impactRepository)
        {
            _impactRepository = impactRepository;
        }

        public Impact DeleteById(Guid id)
        {
            var impact = _impactRepository.Get(selector: x => x, predicate: x => x.Equals(id));

            if(impact == null)
            {
                throw new Exception($"Impact with ID {id} not found.");
            }

            _impactRepository.Delete(impact);
            return impact;
        }

        public List<Impact> GetAll()
        {
           return _impactRepository.GetAll(selector: x => x).ToList();
        }

        public Impact GetById(Guid id)
        {
            return _impactRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Impact Insert(Impact impact)
        {
            impact.Id = Guid.NewGuid();
            return _impactRepository.Insert(impact);
        }

        public Impact Update(Impact impact)
        {
            return _impactRepository.Update(impact);
        }
    }
}
