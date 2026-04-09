using GestionDePagos.InterfacesDelDominio;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public class LimiteGasto : IValidable
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public decimal MontoMaximo { get; set; }
        public decimal ValorAlerta { get; set; }

        public LimiteGasto()
        {
            Id = 0;
        }

        public void Validar()
        {
            if (MontoMaximo <= 0)
                throw new LimiteGastoInvalidoException("El monto máximo debe ser mayor que cero.");
            if (ValorAlerta <= 0)
                throw new LimiteGastoInvalidoException("El valor de alerta debe ser mayor que cero.");
            if (ValorAlerta >= MontoMaximo)
                throw new LimiteGastoInvalidoException("El valor de alerta debe ser menor que el monto máximo.");
        }
    }
}
