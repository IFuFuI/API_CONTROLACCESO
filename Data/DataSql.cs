using aPi_AC.Entidades;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace aPi_AC.Data
{
    public class DataSql : IDisposable
    {

        public IEnumerable <ERespuesta> ERespuest(string RFID , int ACCESO)
        {
            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("RFID", RFID);
                parametros.Add("ACCESO", ACCESO);
                var ListaRespuesta = conexion.Query<ERespuesta>("dbo.SP_OBTENER_RESP", param: parametros, commandType: CommandType.StoredProcedure);
                return ListaRespuesta;
            }
        }


        public int ObRespu(string RFID, int IDEQUIP)
        {

            int lt;

            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var valida = conexion.ExecuteScalar("SELECT dbo.ValidarAcceso('" + RFID + "'," + IDEQUIP + ")", commandType: CommandType.Text);
                lt = Convert.ToInt32(valida.ToString());
                return lt;

            }
        }


        public IEnumerable<EFoliosAC> OBTFOLIOS_AC()
        {
            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var ListaFoliosAC = conexion.Query<EFoliosAC>("dbo.SP_OBTENER_FAC", commandType: CommandType.StoredProcedure);
                return ListaFoliosAC;
            }       
        }

        public IEnumerable<EAcceso> OBTACCESOS()
        {
            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var ListaAccesos = conexion.Query<EAcceso>("dbo.SP_OBTACCESOS", commandType: CommandType.StoredProcedure);
                return ListaAccesos;
            }
        }

        public IEnumerable<EPersmisos> OBTPERMISOS()
        {

            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var ListaPermisos = conexion.Query<EPersmisos>("dbo.SP_OBTPERMISOS", commandType: CommandType.StoredProcedure);
                return ListaPermisos;
            }
        }


        public IEnumerable<EHardCard> OBTHARDCARDS()
        {
            using (IDbConnection conexion = new SqlConnection(SqlConnec.ObtenerConec()))
            {
                conexion.Open();
                var ListaHard = conexion.Query<EHardCard>("dbo.SP_OBTHARDCARDS", commandType: CommandType.StoredProcedure);
                return ListaHard;
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
