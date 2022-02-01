using CommunityProApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetSelected(IList<int> ids);
    }
}
