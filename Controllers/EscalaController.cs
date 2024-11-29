using Microsoft.AspNetCore.Mvc;
using EscalaWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EscalaWebMvc.Data;
using EscalaWebMvc.Models.Enums;

namespace EscalaWebMvc.Controllers
{
    public class EscalaController : Controller
    {
        private readonly EscalaWebMvcContext _context;

        public EscalaController(EscalaWebMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var funcionarios = _context.Func.ToList();
            var areas = _context.Area.ToList();
            var escalas = GerarEscalas(funcionarios, areas);
            return View(escalas);
        }

        private List<Escala> GerarEscalas(List<Func> funcionarios, List<Area> areas)
        {
            var escalas = new List<Escala>();

            // 1. Obter o ano atual e todos os feriados do ano
            int anoAtual = DateTime.Now.Year;
            var feriados = new CalendarioController().ObterFeriados(anoAtual);

            // 2. Identificar todos os finais de semana do ano
            var diasDoAno = Enumerable.Range(1, 365)
                .Select(d => new DateTime(anoAtual, 1, 1).AddDays(d - 1))
                .Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday || feriados.Contains(d))
                .OrderBy(d => d)
                .ToList();

            // 3. Distribuir funcionários por setor e por dia
            var funcionariosPorSetor = funcionarios.GroupBy(f => f.SetorId).ToDictionary(g => g.Key, g => g.ToList());
            var rodizioPorSetor = new Dictionary<int, Queue<Func>>();

            foreach (var setorId in funcionariosPorSetor.Keys)
            {
                rodizioPorSetor[setorId] = new Queue<Func>(funcionariosPorSetor[setorId]);
            }

            foreach (var dia in diasDoAno)
            {
                var escala = new Escala
                {
                    Data = dia,
                    FuncionariosPorTurno = new Dictionary<Area, List<Func>>()
                };

                foreach (var area in areas)
                {
                    var turnoFuncionarios = new List<Func>();

                    if (dia.DayOfWeek == DayOfWeek.Saturday || feriados.Contains(dia))
                    {
                        // Regras para sábados e feriados
                        if (area.Zona == "Musculação")
                        {
                            // 3 manhã, 1 tarde
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 2)); // Manhã
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 1)); // Tarde
                        }
                        else if (area.Zona == "Recepção")
                        {
                            // 1 manhã, 1 tarde
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 1)); // Manhã
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 1)); // Tarde
                        }
                        else if (area.Zona == "Limpeza")
                        {
                            // 2 período integral
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 2)); // Integral
                        }
                    }
                    else if (dia.DayOfWeek == DayOfWeek.Sunday)
                    {
                        // Regras para domingos
                        if (area.Zona == "Musculação" || area.Zona == "Recepção")
                        {
                            // 1 funcionário integral
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 1));
                        }
                        else if (area.Zona == "Limpeza")
                        {
                            // 2 funcionários integral
                            turnoFuncionarios.AddRange(PegarProximosFuncionarios(rodizioPorSetor[area.Id], 2));
                        }
                    }

                    escala.FuncionariosPorTurno[area] = turnoFuncionarios;
                }

                escalas.Add(escala);
            }

            return escalas;
        }

        // Método auxiliar para rodízio de funcionários
        private List<Func> PegarProximosFuncionarios(Queue<Func> filaFuncionarios, int quantidade)
        {
            var selecionados = new List<Func>();

            for (int i = 0; i < quantidade && filaFuncionarios.Count > 0; i++)
            {
                var func = filaFuncionarios.Dequeue();
                selecionados.Add(func);
                filaFuncionarios.Enqueue(func); // Reinsere no final da fila para manter o rodízio
            }

            return selecionados;
        }

    }
}
