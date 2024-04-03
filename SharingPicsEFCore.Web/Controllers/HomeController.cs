using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SharingPicsEFCore.Data;
using SharingPicsEFCore.Web.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace SharingPicsEFCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;
        private readonly IWebHostEnvironment _webEnv;

        public HomeController(IConfiguration config, IWebHostEnvironment webEnv)
        {
            _connectionString = config.GetConnectionString("ConStr");
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            PicRepository repo = new PicRepository(_connectionString);
            HomeViewModel hvm = new HomeViewModel { Pictures = repo.GetPictures() };

            return View(hvm);
        }

        public IActionResult UploadPicture()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(IFormFile image, string title)
        {
            string fullPath = Path.Combine(_webEnv.WebRootPath, "uploads", title);
            using FileStream fs = new FileStream(fullPath, FileMode.Create);
            image.CopyTo(fs);

            PicRepository repo = new PicRepository(_connectionString);
            repo.AddPicture(new Picture
            {
                Title = title,
                DateUploaded = DateTime.Now
            });

            return Redirect("/");
        }

        public IActionResult SubmitImage(IFormFile image, string title)
        {
            PicRepository repo = new PicRepository(_connectionString);
            string path = Path.Combine(_webEnv.WebRootPath, "Uploads", image.FileName);

            Picture here = new Picture
            {
                Title = title,
                Path = image.FileName,
                DateUploaded = DateTime.Now
            };

            using FileStream fs = new FileStream(path, FileMode.Create); 
            image.CopyTo(fs);

            repo.AddPicture(here);

            return Redirect("/");
        }


        public IActionResult ViewImage(int id)
        {
            PicRepository repo = new PicRepository(_connectionString);
            Picture foundIt = repo.GetByID(id);

            var sessionStuff = HttpContext.Session.GetString("can-like");
            bool allow = sessionStuff == null;

            HttpContext.Session.SetString("can-like", "no");

            return View(new ViewImageViewModel 
            { 
                Picture = foundIt,
                CanLike = allow
            });
        }

        public void IncreaseLikes(int picId)
        {
            PicRepository repo = new PicRepository(_connectionString);
            Picture foundIt = repo.GetByID(picId);

            foundIt.Likes += 1;
        }
    }
}