using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscalaWebMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EscalaWebMvc.Models
{
    public class Escala

    {
        [Key] //definir a chave primaria
        public int Id { get; set; }
        private List<Func> Funcionario { get; set; } = new List<Func>();
        private List<Area> Area { get; set; } = new List<Area>();

        //aqui ficará a lógica de montagem da escala

        public Escala() 
        {
        }

        public Escala(int id)
        {
            Id = id;
        }
    }
}
