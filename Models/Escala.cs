using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EscalaWebMvc.Models.Enums;


namespace EscalaWebMvc.Models
{
    public class Escala
    {
        public DateTime Data { get; set; }

        [NotMapped] // Ignora essa propriedade no mapeamento do EF Core
        public Dictionary<Area, List<Func>> FuncionariosPorTurno { get; set; }

        public Escala() { }

        public Escala(DateTime data, List<Func> funcionarios, List<Area> areas)
        {
            Data = data;
            FuncionariosPorTurno = new Dictionary<Area, List<Func>>();
        }

    }

}


