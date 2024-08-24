using Microsoft.AspNetCore.Server.HttpSys;
using System.Security.Principal;

namespace lista04Humberto.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }



        public double IMC()
        {
            return (Weight / (Height * Height));
        }
    }
}
