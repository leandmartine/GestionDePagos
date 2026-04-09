using System;
using GestionDePagos.InterfacesDelDominio;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public class Categoria : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public Categoria()
        {
            Id = 0;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new CategoriaInvalidaException("El nombre de la categoría no puede estar vacío.");
        }
    }
}
