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
    }
}
