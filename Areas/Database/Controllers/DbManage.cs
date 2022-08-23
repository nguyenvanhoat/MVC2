using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC2.Models;

namespace MVC2.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("database-manage/[action]")]
    public class DbManage : Controller
    {
        private readonly ILogger<DbManage> _logger;
        private readonly AppDbContext _dbcontext;

        public DbManage(ILogger<DbManage> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}