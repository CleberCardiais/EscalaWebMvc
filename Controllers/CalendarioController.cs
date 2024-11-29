using Microsoft.AspNetCore.Mvc;
using EscalaWebMvc.Models;
using System;
using System.Collections.Generic;
using EscalaWebMvc.Models.Enums;

namespace EscalaWebMvc.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Index(int? ano, int? mes)
        {
            int anoAtual = ano ?? DateTime.Now.Year;
            int mesAtual = mes ?? DateTime.Now.Month;

            // Normalizar valores de ano e mês
            if (mesAtual < 1)
            {
                mesAtual = 12;
                anoAtual--;
            }
            else if (mesAtual > 12)
            {
                mesAtual = 1;
                anoAtual++;
            }

            var feriados = ObterFeriados(anoAtual);

            var calendario = new Calendario(anoAtual, mesAtual, feriados);
            return View(calendario);
        }

        public List<DateTime> ObterFeriados(int ano)
        {
            return new List<DateTime>
    {
        //new DateTime(ano, 1, 1), // Ano Novo sem funcionamento
        new DateTime(ano, 1, 25), // Aniversário de São Paulo
        CalcularDataPascoa(ano).AddDays(-48), // Carnaval (segunda-feira)
        CalcularDataPascoa(ano).AddDays(-47), // Carnaval (terça-feira)
        CalcularDataPascoa(ano).AddDays(-2), // Sexta-feira Santa
        CalcularDataPascoa(ano), // Páscoa
        new DateTime(ano, 4, 21), // Tiradentes
        //new DateTime(ano, 5, 1), // Dia do Trabalho sem funcionamento
        //new DateTime(ano, 6, 29), // São Pedro (Osasco) confirmar feriado
        CalcularDataCorpusChristi(ano), // Corpus Christi
        new DateTime(ano, 7, 9), // Revolução Constitucionalista (SP)
        new DateTime(ano, 9, 7), // Independência do Brasil
        new DateTime(ano, 10, 12), // Nossa Senhora Aparecida
        //new DateTime(ano, 10, 28), // Dia do Funcionário Público ponto facultativo
        new DateTime(ano, 11, 2), // Finados
        new DateTime(ano, 11, 15), // Proclamação da República
        new DateTime(ano, 11, 20), //Consciência Negra
        //new DateTime(ano, 12, 25) // Natal sem funcionamento
    };
        }

        // Função para calcular a data da Páscoa
        private DateTime CalcularDataPascoa(int ano)
        {
            int a = ano % 19;
            int b = ano / 100;
            int c = ano % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int mes = (h + l - 7 * m + 114) / 31;
            int dia = ((h + l - 7 * m + 114) % 31) + 1;
            return new DateTime(ano, mes, dia);
        }

        // Função para calcular Corpus Christi (60 dias após a Páscoa)
        private DateTime CalcularDataCorpusChristi(int ano)
        {
            return CalcularDataPascoa(ano).AddDays(60);
        }
    }

}