using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [TempData]
        public string StatusMessage { get; set;}

        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success =await _dbcontext.Database.EnsureDeletedAsync();

            StatusMessage = success ? "Xóa Thành Công" : "Không thể xóa";

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _dbcontext.Database.MigrateAsync();

            StatusMessage = "Tạo DB Thành công";

            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}