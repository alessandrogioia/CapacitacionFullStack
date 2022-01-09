using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Helpers;

namespace Website.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult DownloadImage(string filename)
        {
            string filepath = FileHelper.filePath + filename;

            byte[] bytes = System.IO.File.ReadAllBytes(filepath);

            return File(bytes, "image/");
        }
    }
}