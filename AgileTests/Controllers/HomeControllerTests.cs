using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            List<int> twos = new List<int>{ 2, 4, 6, 8, 10, 12, 14, 16};
            List<int> threes = new List<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };

            var query = twos.Intersect(threes);
            Console.WriteLine("Interset");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }


            var unionQuery = twos.Union(threes);
            Console.WriteLine("Union");
            foreach (var item in unionQuery)
            {
                Console.WriteLine(item);
            }


            var exceptQuery = twos.Except(threes);
            Console.WriteLine("Except");
            foreach (var item in exceptQuery)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void WhereSelect()
        {
            List<string> names =  new List<string>{ "Dave", "Polly", "Nick", "JohnBrown"};

            var query = names.Where(x => x.Length > 4)
                             .Select(x => x.Length);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }
    }
}