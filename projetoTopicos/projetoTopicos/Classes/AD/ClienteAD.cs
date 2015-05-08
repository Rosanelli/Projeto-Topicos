using projetoTopicos.classes.EN;
using projetoTopicos.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projetoTopicos.classes.AD
{
    public class ClienteAD
    {

        public static List<ClienteEN> Busca_Todos_Clientes()
        {
            List<ClienteEN> lista = new List<ClienteEN>();

            var query = @"SELECT ID,nome,telefone,sexo FROM CLIENTE";

            using (var conexao = new Conexao())
            {
                SqlDataReader reader = conexao.ExecuteQuery(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClienteEN en = new ClienteEN();
                        en._ID = Convert.ToInt32(reader["ID"]);
                        en._Nome = reader["nome"].ToString();
                        en._telefone = reader["telefone"].ToString();
                        en._Sexo = reader["sexo"].ToString();
                        
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

        public static ClienteEN BuscaCliente(int id)
        {
            ClienteEN en = new ClienteEN();

            var query = string.Format(@"SELECT ID,nome,telefone,sexo FROM CLIENTE
                                         WHERE ID = '{0}'", id);

            using (var conexao = new Conexao())
            {
                SqlDataReader reader = conexao.ExecuteQuery(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        en._ID = id;
                        en._Nome = reader["nome"].ToString();
                        en._telefone = reader["telefone"].ToString();
                        en._Sexo = reader["sexo"].ToString();
                    }
                }
                else
                {
                    en = null;
                }
            }

            return en;
        }

        public static void InseriCliente(ClienteEN en)
        {
            var query = @"INSERT INTO CLIENTE
                          VALUES(@nome,@telefone,@sexo)";

            using (var conexao = new Conexao())
            {
                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@nome", en._Nome);
                command.Parameters.AddWithValue("@telefone", en._telefone);
                command.Parameters.AddWithValue("@sexo", en._Sexo);
                
                conexao.ExecuteNonQuery(command);
            }

        }

        public static void AlteraCliente(ClienteEN en)
        {
            using (var conexao = new Conexao())
            {

                var query = @"UPDATE CLIENTE
                              SET nome = @NOME,
                                  telefone = @TELEFONE,
                                  sexo = @SEXO
                                  WHERE ID = @ID";

                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@NOME", en._Nome);
                command.Parameters.AddWithValue("@TELEFONE", en._telefone);
                command.Parameters.AddWithValue("@SEXO", en._Sexo);
                command.Parameters.AddWithValue("@ID", en._ID);

                conexao.ExecuteNonQuery(command);
            }
        }

        public static void ExcluiCliente(int id)
        {
            using (var conexao = new Conexao())
            {

                var query = @"DELETE FROM CLIENTE
                               WHERE ID = @ID";

                var command = conexao.CreateCommand(query);
                command.Parameters.AddWithValue("@ID", id);

                conexao.ExecuteNonQuery(command);
            }
        }

    }
}