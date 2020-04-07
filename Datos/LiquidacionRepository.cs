using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class LiquidacionRepository
    {
        private readonly SqlConnection Connection;
        private readonly List<Liquidacion> Liquidaciones = new List<Liquidacion>();

        public LiquidacionRepository(ConnectionManager connection)
        {
            Connection = connection._conexion;
        }

        public void Guardar(Liquidacion liquidacion)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Liquidaciones (IdentificacionDelPaciente,ValorDelServicio,SalarioDeTrabajador, ValorCopago, Tarifa) 
                                        values (@IdentificacionDelPaciente,@ValorDelServicio,@SalarioDeTrabajador,@ValorCopago,@Tarifa)";
                command.Parameters.AddWithValue("@IdentificacionDelPaciente", liquidacion.IdentificacionDelPaciente);
                command.Parameters.AddWithValue("@ValorDelServicio", liquidacion.ValorDelServicio);
                command.Parameters.AddWithValue("@SalarioDeTrabajador", liquidacion.SalarioDeTrabajador);
                command.Parameters.AddWithValue("@ValorCopago", liquidacion.ValorCopago);
                command.Parameters.AddWithValue("@Tarifa", liquidacion.Tarifa);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Liquidacion> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Liquidacion> personas = new List<Liquidacion>();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "Select * from Liquidaciones";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToPerson(dataReader);
                        personas.Add(liquidacion);
                    }
                }
            }
            return personas;
        }

        private Liquidacion DataReaderMapToPerson(SqlDataReader dataReader)
{
            if(!dataReader.HasRows) return null;
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.IdentificacionDelPaciente = (string)dataReader["IdentificacionDelPaciente"];
            liquidacion.ValorDelServicio = (decimal)dataReader["ValorDelServicio"];
            liquidacion.SalarioDeTrabajador = (decimal)dataReader["SalarioDeTrabajador"];
            liquidacion.ValorCopago = (decimal)dataReader["ValorCopago"];
            liquidacion.Tarifa = (decimal)dataReader["Tarifa"];
            return liquidacion;
}



    }
}
