using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "State/Department")]
        [Required(ErrorMessage ="Field {0} is required")]
        [MaxLength(100,ErrorMessage ="Field {0} can't have more than {1) characters")]
        public string Name { get; set; } = null!;


        //relations db

        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; }
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
