using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class LiquidacionService
    {
        private readonly ConnectionManager _conexion;
        private readonly LiquidacionRepository liquidacionRepository;

        public LiquidacionService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            liquidacionRepository = new LiquidacionRepository(_conexion);
        }

        public ConsultarTodosResponse ConsultarTodos()
        {
            try
            {
                _conexion.Open();
                List<Liquidacion> liquidaciones = liquidacionRepository.ConsultarTodos();
                _conexion.Close();
                return new ConsultarTodosResponse(liquidaciones);
            }
            catch (Exception e)
            {
                return new ConsultarTodosResponse(e.Message);
            }

        }

        public GuardarPersonaResponse Guardar(Liquidacion liquidacion)
        {
            try
            {
                liquidacion.CalcularCopago();
                _conexion.Open();
                liquidacionRepository.Guardar(liquidacion);
                _conexion.Close();
                return new GuardarPersonaResponse(liquidacion);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }




        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(Liquidacion liquidacion)
            {
                Error = false;
                Liquidacion = liquidacion;
            }
            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Liquidacion Liquidacion { get; set; }

        }


        public class ConsultarTodosResponse
    {
        public ConsultarTodosResponse(List<Liquidacion> liquidaciones)
        {
            Error = false;
            Liquidaciones = liquidaciones;
        }
        public ConsultarTodosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Liquidacion> Liquidaciones { get; set; }
    }
    }
}
