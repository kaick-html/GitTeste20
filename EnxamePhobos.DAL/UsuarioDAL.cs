using EnxamePhobos.DTO;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DAL
{
    public class UsuarioDAL : Conexao
    {
        //autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Nome, Senha, TipoUsuario_Id FROM Usuario WHERE Nome = @Nome AND Senha = @Senha ", conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Senha", senha);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Usuário não cadastrado" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }



        //CRUD
        //list
        public List<UsuarioDTO> Listar()
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Usuario.Id, Nome, Email, Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.TipoUsuario_Id = TipoUsuario.Id ORDER BY Usuario.Id ASC;", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> Lista = new List<UsuarioDTO>(); //lista vazia
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"].ToString());
                    obj.TipoUsuario_Id = dr["Descricao"].ToString();
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Deu ruim " + ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }



        //carrega DDL(DropDawList)
        public List<TipoUsuarioDTO> CarregaDDL()
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> Lista = new List<TipoUsuarioDTO>(); //lista vazia
                while (dr.Read())
                {
                    TipoUsuarioDTO obj = new TipoUsuarioDTO();
                    obj.id = Convert.ToInt32(dr["Id"]);
                    obj.Descricao = dr["Descricao"].ToString();
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Deu merda!!!!" + ex.Message);
            }
            finally
            {

                Desconectar();

            }


        }


        //busca por nome
        public UsuarioDTO SearchName(string objSearch)
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand("SELECT * FROM usuario WHERE usuario.nome = @Nome;", conn);
                cmd.Parameters.AddWithValue("@Nome", objSearch);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {

                    obj = new UsuarioDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Deu merda!!!" + ex.Message);
            }
            finally
            {

                Desconectar();

            }

        }


        //busca por id
        public UsuarioDTO SearchId(int objSearch)
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand("SELECT * FROM usuario WHERE usuario.id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objSearch);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {

                    obj = new UsuarioDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Deu merda!!!" + ex.Message);
            }
            finally
            {

                Desconectar();

            }

        }

        public void Cadastrar(UsuarioDTO objCad)
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_Id) VALUES (@Nome,@Email,@Senha,@DataNascUsuario,@TipoUsuario_Id )", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.Nome);
                cmd.Parameters.AddWithValue("@Email", objCad.Email);
                cmd.Parameters.AddWithValue("@Senha", objCad.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", objCad.TipoUsuario_Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu merda!!" + ex.Message);

            }
            finally
            {

                Desconectar();

            }
        }

        public void Update(UsuarioDTO objUpdt)
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE usuario SET Nome=@Nome, Email=@Email, Senha=@Senha, DataNascUsuario=@DataNascUsuario, TipoUsuario_Id=@TipoUsuario_Id WHERE usuario.Id= @Id", conn);
                cmd.Parameters.AddWithValue("@Nome", objUpdt.Nome);
                cmd.Parameters.AddWithValue("@Email", objUpdt.Email);
                cmd.Parameters.AddWithValue("@Senha", objUpdt.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objUpdt.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", objUpdt.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@Id", objUpdt.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu merda!!" + ex.Message);

            }
            finally
            {

                Desconectar();

            }

        }


        //delete
      
        public void Delete(int objDel) 
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Usuario WHERE Usuario.Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu Merda !" + ex.Message);
            }
            finally 
            {
            
                Desconectar();

            }

        }
       























    }
}
