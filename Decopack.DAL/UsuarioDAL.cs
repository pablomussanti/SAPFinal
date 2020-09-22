using Decopack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Decopack.DAL
{
    public partial class UsuarioDAL : DataAccessComponent, IRepository<Usuario>
    {
        public Usuario Create(Usuario Usuario)
        {
            const string StoreProcedure = "s_Usuario_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Contraseña", DbType.AnsiString, Usuario.contraseña);
                db.AddInParameter(cmd, "@Estadobloqueado", DbType.Double, Usuario.estadobloqueado);
                db.AddInParameter(cmd, "@User", DbType.AnsiString, Usuario.user);
                Usuario.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Usuario;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Usuario_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codusuario", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Usuario> Read()
        {
            const string StoreProcedure = "s_Usuario_Listar";

            List<Usuario> result = new List<Usuario>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Usuario Usuario = LoadUsuario(dr);
                        result.Add(Usuario);
                    }
                }
            }
            return result;
        }

        public Usuario ReadBy(int id)
        {
            const string StoreProcedure = "s_Usuario_TraerUno";
            Usuario Usuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codusuario", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Usuario = LoadUsuario(dr);
                    }
                }
            }
            return Usuario;
        }

        public void Update(Usuario Usuario)
        {
            const string StoreProcedure = "s_Usuario_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codusuario", DbType.AnsiString, Usuario.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Usuario.user);
                db.AddInParameter(cmd, "@Precio", DbType.Double, Usuario.contraseña);
                db.AddInParameter(cmd, "@Estado", DbType.String, Usuario.estadobloqueado);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Usuario LoadUsuario(IDataReader dr)
        {
            Usuario Usuario = new Usuario();
            Usuario.Id = GetDataValue<int>(dr, "Codusuario");
            Usuario.user = GetDataValue<string>(dr, "Username");
            Usuario.estadobloqueado = GetDataValue<string>(dr, "Estadobloqueado");
            Usuario.contraseña = GetDataValue<string>(dr, "Contraseña");

            return Usuario;
        }
    }
}
