using System;

namespace Entity
{
    public class Liquidacion
    {
       
        public string IdentificacionDelPaciente { get; set; }
        public decimal ValorDelServicio { get; set; }
        public decimal SalarioDeTrabajador { get; set; }
        public decimal ValorCopago { get; set; }
        public decimal Tarifa { get; set; }

        const decimal limite = 2500000;
        public void CalcularCopago(){
            if(SalarioDeTrabajador>limite){
                Tarifa = 0.2m;
            }else{
                Tarifa = 0.1m;
            }
            ValorCopago = Tarifa * ValorDelServicio;
        }
    }
}
