using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}