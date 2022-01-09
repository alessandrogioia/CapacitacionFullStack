using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Website.Helpers
{
    public static class FileHelper
    {
        public const string filePath = @"C:\ProjectFileStorage\";

        public static string SubirArchivo(HttpPostedFileBase file)
        {
            //Obtengo Extension
            string extension = Path.GetExtension(file.FileName);

            //Genero Id
            string filename = Guid.NewGuid().ToString() + extension;
            
            string path = filePath + filename;

            //Obtengo el byte[] de la File enviada
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] bytes = target.ToArray();

            //Guardo en Disco
            System.IO.File.WriteAllBytes(path, bytes);

            return filename;
        }

    }
}