using projetoTopicos.classes.EN;
using projetoTopicos.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projetoTopicos.classes.AD
{
    public class UsuarioAD
    {
        public static UsuarioEN AutenticaUsuario(string usuario, string senha)
        {

            var query = String.Format(@"SELECT * FROM USUARIO
                                          WHERE Usuario = '{0}' AND Senha = '{1}'", usuario, senha);

            UsuarioEN en = new UsuarioEN();

            using (var conexao = new Conexao())
            {

                SqlDataReader reader = conexao.ExecuteQuery(query);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        en._nome = reader["nome"].ToString();
                        en._usuario = reader["usuario"].ToString();
                        en._senha = reader["senha"].ToString();
                        en._tipo = reader["tipo"].ToString();
                    }
                }
                else
                {
                    en = null;
                }
            }

            return en;
        }

        public static List<UsuarioEN> Busca_Todos_Usuario()
        {
            List<UsuarioEN> lista = new List<UsuarioEN>();

            var query = @"SELECT id,nome,usuario,senha,tipo FROM USUARIO";

            using (var conexao = new Conexao())
            {
                SqlDataReader reader = conexao.ExecuteQuery(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UsuarioEN en = new UsuarioEN();
                        en._id = Convert.ToInt32(reader["id"]);
                        en._nome = reader["nome"].ToString();
                        en._usuario = reader["usuario"].ToString();
                        en._senha = reader["senha"].ToString();
                        en._tipo = reader["tipo"].ToString();

                        lista.Add(en);
                    }
                }
                else
                {
                    lista = null;
                }
            }

            return lista;
        }

        public static UsuarioEN BuscaUsuario(int id)
        {
            UsuarioEN en = new UsuarioEN();

            var query =  string.Format(@"SELECT id,nome,usuario,senha,tipo FROM USUARIO
                                         WHERE id = '{0}'",id);

            using (var conexao = new Conexao())
            {
                SqlDataReader reader = conexao.ExecuteQuery(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        en._id = id;
                        en._nome = reader["nome"].ToString();
                        en._usuario = reader["usuario"].ToString();
                        en._senha = reader["senha"].ToString();
                        en._tipo = reader["tipo"].ToString();
                    }
                }
                else
                {
                    en = null;
                }
            }

            return en;
        }

        public static void InseriUsuario(UsuarioEN en)
        {
            var query = @"INSERT INTO USUARIO
                          VALUES(@nome,@usuario,@senha,@tipo)";

            using (var conexao = new Conexao())
            {
                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@nome", en._nome);
                command.Parameters.AddWithValue("@usuario", en._usuario);
                command.Parameters.AddWithValue("@senha", en._senha);
                command.Parameters.AddWithValue("@tipo", en._tipo);

                conexao.ExecuteNonQuery(command);
            }

        }

        public static void AlteraUsuario(UsuarioEN en)
        {
            using (var conexao = new Conexao())
            {

                var query = @"UPDATE USUARIO
                              SET nome = @NOME,
                                  usuario = @USUARIO,
                                  senha = @SENHA,
                                  tipo = @TIPO
                                  WHERE ID = @ID";

                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@NOME", en._nome);
                command.Parameters.AddWithValue("@USUARIO", en._usuario);
                command.Parameters.AddWithValue("@SENHA", en._senha);
                command.Parameters.AddWithValue("@TIPO", en._tipo);
                command.Parameters.AddWithValue("@ID", en._id);

                conexao.ExecuteNonQuery(command);
            }
        }

        public static void ExcluiUsuario(int id)
        {
            using (var conexao = new Conexao())
            {

                var query = @"DELETE FROM USUARIO
                               WHERE ID = @ID";

                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@ID", id);

                conexao.ExecuteNonQuery(command);
            }
        }
    }
}