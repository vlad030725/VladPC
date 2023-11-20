using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompContext db = new CompContext())
            {
                db.Company.Select(i => i).ToList();
            }
        }
    }
}
