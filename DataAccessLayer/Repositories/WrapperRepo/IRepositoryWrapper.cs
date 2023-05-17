using DataAccessLayer.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.WrapperRepo
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task SaveAsync();

    }
}
