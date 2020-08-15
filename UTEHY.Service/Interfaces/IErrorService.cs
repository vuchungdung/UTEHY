using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;

namespace UTEHY.Service.Interfaces
{
    public interface IErrorService
    {
        void Add(Error error);
        void Save();
    }
}
