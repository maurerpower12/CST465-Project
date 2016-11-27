using MVC465.Code;
using MVC465.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC465.Controllers
{
    public class ImageController : Controller
    {
        private ImageDBRepository _Repo;
        public ImageController()
        {
            _Repo = new ImageDBRepository();
        }
        // GET: Image
        public ActionResult Index()
        {
            List<Image> images = _Repo.GetList();
            return View(images);
        }
        public ActionResult Show(int id)
        {
            Image image = _Repo.Get(id);
            image.ContentType = "jpeg";
            image.FileName = (string)"ex";
            return File(image.FileData, image.ContentType, image.FileName);
        }
        public ActionResult Add()
        {
            return View(new ImageModel());
        }
        [HttpPost]
        public ActionResult Add(ImageModel imageModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                return View(imageModel);
            }
            else
            {
                if (imageModel.SampleImage != null )
                {
                    if (imageModel.SampleImage.ContentLength < 5000)
                    {
                        Image image = new Image();
                        image.ID = imageModel.ID;
                        byte[] imageBytes;

                        using (var memoryStream = new MemoryStream())
                        {
                            imageModel.SampleImage.InputStream.CopyTo(memoryStream);
                            imageBytes = memoryStream.ToArray();
                        }
                        image.FileData = imageBytes;
                        image.FileName = imageModel.SampleImage.FileName;
                        image.ContentType = imageModel.SampleImage.ContentType;
                        _Repo.Save(image);
                    }
                    else
                    {
                        throw new Exception("Image too big.");
                    }
                }
                return RedirectToAction("Index", "Inventory");
            }
        }
    }
}