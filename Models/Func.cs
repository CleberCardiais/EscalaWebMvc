using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscalaWebMvc.Models.Enums;

namespace EscalaWebMvc.Models
{
    public class Func
    {
        public int Id { get; set; }

        public int SetorId { get; set; }
        public string? Name { get; set; }

        public  Area? Setor { get; set; }

        public Func() 
        { 
        }

        public Func(int id, int setorId, string? name)
        {
            Id = id;
            SetorId = setorId;
            Name = name;
        }
    }
}


