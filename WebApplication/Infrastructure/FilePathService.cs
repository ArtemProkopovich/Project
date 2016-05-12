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
            long ticks = DateTime.Now.Ticks;
            long magicNumber = random.Next() ^ ticks;
        }
    }
}