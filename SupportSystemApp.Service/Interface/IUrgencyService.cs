using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface IUrgencyService
    {
        List<Urgency> GetAll();
        Urgency GetById(Guid id);
        Urgency Insert(Urgency urgency);
        Urgency Update(Urgency urgency);
        Urgency DeleteById(Guid id);
    }
}
