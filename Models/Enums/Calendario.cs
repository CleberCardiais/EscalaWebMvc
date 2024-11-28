using System;
using System.Collections.Generic;
using System.Globalization;

namespace EscalaWebMvc.Models.Enums;

public class Calendario
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public List<DateTime> Dias { get; set; } = new List<DateTime>();
    public List<DateTime> Feriados { get; set; } = new List<DateTime>();

    public Calendario(int ano, int mes, List<DateTime> feriados)
    {
        Ano = ano;
        Mes = mes;
        Feriados = feriados;
        GerarDias();
    }

    private void GerarDias()
    {
        var primeiroDia = new DateTime(Ano, Mes, 1);
        var totalDias = DateTime.DaysInMonth(Ano, Mes);
        for (int i = 0; i < totalDias; i++)
        {
            Dias.Add(primeiroDia.AddDays(i));
        }
    }

    public bool IsFeriado(DateTime dia)
    {
        return Feriados.Contains(dia);
    }

    public bool IsFinalDeSemana(DateTime dia)
    {
        return dia.DayOfWeek == DayOfWeek.Saturday || dia.DayOfWeek == DayOfWeek.Sunday;
    }
}
