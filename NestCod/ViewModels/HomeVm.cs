using NestCod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestCod.ViewModels
{
    public class HomeVm
    {
        public List<Sliders> Sliders { get; set; }
        public List<Catecori> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> RecentProducts { get; set; }
        public List<Product> TopRatedProducts { get; set; }
    }
}
