using SupportSystemApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface IService_CategoryService
    {
        List<Service_Category> GetAll();
        Service_Category GetById(Guid id);
        Service_Category Insert(Service_Category service_Category);
        Service_Category Update(Service_Category service_Category);
        Service_Category DeleteById(Guid id);
    }
}
