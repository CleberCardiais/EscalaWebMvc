using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EscalaWebMvc.Models
{
    public class Area
    {

        public int Id { get; set; }
        public string Zona { get; set; }
        public ICollection<Func> Funcionario { get; set; } = new List<Func>();

        public Area()
        { 
        }

        public Area(int id, string zona)
        {
            Id = id;
            Zona = zona;
        }
    }
}
