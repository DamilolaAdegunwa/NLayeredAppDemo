using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Application.Dto.Products
{
    public class ProductGridOutput
    {
        public int Id { get; set; }

        [Display(Name = "Name of the Product")]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string UserModified { get; set; }
    }
}
