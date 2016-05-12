using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Infrastructure
{
    public static class FilePathGenerator
    {
        private static Random random = new Random(); 
        public static string GenerateFileName(string fileName)
        {
            int num = fileName.Length - 1;
            while (fileName[num--] != '.') ;
            string ext = fileName.Substring(num + 1);
            long ticks = DateTime.Now.Ticks;
            long magicNumber = random.Next() ^ ticks;
            unchecked
            {
                magicNumber = fileName.Aggregate(magicNumber, (current, c) => current ^ (c*random.Next(int.MaxValue)));
            }
            magicNumber = magicNumber < 0 ? -1*magicNumber : magicNumber;
            return magicNumber + ext;
        }
    }
}