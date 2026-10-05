using SupportSystemApp.Domain.Domain_Models;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class Service_CategoryService : IService_CategoryService
    {
        private readonly IRepository<Service_Category> _serviceCategoryRepository;

        public Service_CategoryService(IRepository<Service_Category> serviceCategoryRepository)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
        }

        public Service_Category DeleteById(Guid id)
        {
            var serviceCategory = _serviceCategoryRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if(serviceCategory == null)
            {
                throw new Exception($"Service category with ID {id} not found.");
            }

            _serviceCategoryRepository.Delete(serviceCategory);
            return serviceCategory;
        }

        public List<Service_Category> GetAll()
        {
            return _serviceCategoryRepository.GetAll(selector: x => x).ToList();
        }

        public Service_Category GetById(Guid id)
        {
            return _serviceCategoryRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Service_Category Insert(Service_Category service_Category)
        {
            service_Category.Id = Guid.NewGuid();
            return _serviceCategoryRepository.Insert(service_Category);
        }

        public Service_Category Update(Service_Category service_Category)
        {
            return _serviceCategoryRepository.Update(service_Category);
        }
    }
}