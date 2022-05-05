using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Dtos.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage ="Product name couldn't be empty")]
        [MinLength(3,ErrorMessage ="Product name should be least 3 char")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string ImageURL { get; set; }
    }
}
