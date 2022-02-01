using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }

    public class CreateCategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class UpdateCategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
