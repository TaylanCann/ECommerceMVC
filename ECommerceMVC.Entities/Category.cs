using ECommerceMVC.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public DateTime? CreatedDate { get ; set ; }
        public DateTime? UpdateDate { get ; set ; }
        public bool? IsActive { get; set; } = true;
    }
}
