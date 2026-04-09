using Microsoft.EntityFrameworkCore;
using System;

namespace GestionDePagos.ValueObjects
{
    [Owned]
    public sealed class Direccion
    {
        public string Calle { get; init; } = string.Empty;
        public string Ciudad { get; init; } = string.Empty;
        public string CodigoPostal { get; init; } = string.Empty;

        public Direccion(string calle, string ciudad, string codigoPostal)
        {
            Calle = calle ?? string.Empty;
            Ciudad = ciudad ?? string.Empty;
            CodigoPostal = codigoPostal ?? string.Empty;
        }
    }
}
