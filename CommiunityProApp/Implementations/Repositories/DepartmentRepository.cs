using CommunityProApp.Context;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>,  IDepartmentRepository
    {
        public DepartmentRepository( ApplicationContext context)
        {
            _context = context;
        }
    }
}
