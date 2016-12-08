using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace TestEFMVCCancel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDbContext _dbContext;

        public HomeController(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
           
            var cts = new CancellationTokenSource();
            try
            {
                var query = _dbContext.TestModels.ToListAsync(cts.Token);
                cts.Cancel();
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
