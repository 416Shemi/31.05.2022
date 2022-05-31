using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestCod.DAL;
using NestCod.Models;
using NestCod.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestCod.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<Product> query = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).AsQueryable();
            HomeVm homeVM = new HomeVm()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync(),
                Products = await query.OrderByDescending(p => p.Id).Take(10).ToListAsync(),
                RecentProducts = await query.OrderByDescending(p => p.Id).Take(3).ToListAsync(),
                TopRatedProducts = await query.OrderByDescending(p => p.Raiting).Take(3).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
