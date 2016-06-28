using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Infrastructure
{
    public class RandomInit
    {
        private static Random random = new Random();
        public static Random GetRandom()
        {
            int next = 100;
            for (int i = 0; i < 10; i++)
            {
                next = random.Next(next);
                for (int j = 0; j < 10; j++)
                {
                    next = random.Next(next);
                }
                next = random.Next(DateTime.Now.Millisecond);
            }
            return random;
        }
    }
}