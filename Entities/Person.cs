using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace file.Entities
{
    public class Person
    {
        public int Id{get; private set;} = GenerateUniqueOrderNo();
        public string Name{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public string Address{get; set;}

        private static int GenerateUniqueOrderNo(){

            var rand = new Random();
            return rand.Next(1, int.MaxValue);

        }

    }
}