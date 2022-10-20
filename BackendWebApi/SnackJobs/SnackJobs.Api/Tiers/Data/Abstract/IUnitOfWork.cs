using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Abstract
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        void Complete();
    }
}
