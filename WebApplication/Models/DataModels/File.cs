using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Infrastructure;

namespace WebApplication.Models.DataModels
{
    public class File
    {
        public static string SaveFile(HttpServerUtilityBase server, HttpPostedFileBase file, string directory)
        {
            string filepath = server.MapPath(directory + FilePathGenerator.GenerateFileName(file.FileName));
            file.SaveAs(filepath);
            return filepath;
        }
    }
}