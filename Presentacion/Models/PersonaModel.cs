using Entity;

namespace Presentacion.Models
{
    public class LiquidacionInputModel
    {
        public string IdentificacionDelPaciente { get; set; }
        public decimal ValorDelServicio { get; set; }
        public decimal SalarioDeTrabajador { get; set; }
    }

    public class LiquidacionViewModel : LiquidacionInputModel
    {
        public LiquidacionViewModel()
        {

        }
        public LiquidacionViewModel(Liquidacion liquidacion)
        {
            IdentificacionDelPaciente = liquidacion.IdentificacionDelPaciente;
            ValorDelServicio = liquidacion.ValorDelServicio;
            SalarioDeTrabajador = liquidacion.SalarioDeTrabajador;
            ValorCopago = liquidacion.ValorCopago;
            Tarifa = liquidacion.Tarifa;
        }
        public decimal ValorCopago { get; set; }
        public decimal Tarifa { get; set; }
    }

}