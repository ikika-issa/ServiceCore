using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface IImpactService
    {
        List<Impact> GetAll();
        Impact GetById(Guid id);
        Impact Insert(Impact impact);
        Impact Update(Impact impact);
        Impact DeleteById(Guid id);
    }
}
