using GestionDePagos.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestionDePagos.ValueObjects
{
    [Owned]
    public sealed class Dinero
    {
        public decimal Valor { get; init; }
        public Moneda Moneda { get; init; }

        public Dinero(decimal valor, Moneda moneda)
        {
            Valor = valor;
            Moneda = moneda;
        }

        public decimal EnPesos(decimal tasa)
        {
            // Si la moneda ya es UYU no se aplica tasa, de lo contrario se convierte
            return Moneda == Moneda.UYU ? Valor : Valor * tasa;
        }
    }
}
