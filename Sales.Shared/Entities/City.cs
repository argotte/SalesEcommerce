using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sales.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "Field {0} is required")]
        [MaxLength(100, ErrorMessage = "Field {0} can't have more than {1) characters")]
        public string Name { get; set; } = null!;
        
        
        //relations db
        public State? State { get; set; }

    }
}
