using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Entities
{
    public class Comment : BaseEntity
    {
        public string ProductComment { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Guid CustomerId { get; set; }

        public User Customer { get; set; }

        public int? ProductRating { get; set; }

    }
}
