using System;
using Newtonsoft.Json;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myPerson = new Person()
            {
                Name = "Luc",
                Age = 41
            };

            // var jsonStr = JsonConvert.SerializeObject(myPerson);
            var jsonStr = JsonConvert.SerializeObject(myPerson, new JsonSerializerSettings() { Formatting = Formatting.Indented });

            Console.WriteLine(jsonStr);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Hello(bool isLowercase)
        {
            var res = $"HELLO {Name}, YOU ARE {Age}";
            if(isLowercase)
                return res.ToLower();
            return res;
        }
    }
}
