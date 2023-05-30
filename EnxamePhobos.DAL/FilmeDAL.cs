using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnxamePhobos.DTO;//
using MySql.Data.MySqlClient;//

namespace EnxamePhobos.DAL
{
    public class FilmeDAL : Conexao
    {


        public List<FilmeDTO> Listar()
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id,titulo,produtora,urlimg,genero.GeneroDescricao,classificacao.ClassificacaoDescricao FROM filme INNER JOIN genero ON genero_id = genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id ORDER BY filme.id ASC;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>(); //lista vazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["GeneroDescricao"].ToString();
                    obj.Classificacao_Id = dr["ClassificacaoDescricao"].ToString();
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

        public FilmeDTO SearchFilme(string objSearch)
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand(" SELECT filme.Id,Titulo,Produtora,UrlImg,Genero_Id,ClassificacaoDescricao FROM filme INNER JOIN classificacao ON classificacao_Id = classificacao.Id WHERE filme.Titulo = @Titulo; ", conn);
                cmd.Parameters.AddWithValue("@Titulo", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {

                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
                    obj.Classificacao_Id = dr["ClassificacaoDescricao"].ToString();
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

        public List<FilmeDTO> FiltrarFilme(string objFilter)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.Id,Titulo,Produtora,UrlImg,GeneroDescricao,ClassificacaoDescricao FROM filme INNER JOIN classificacao ON classificacao_Id = classificacao.Id INNER JOIN genero ON Genero_Id = Genero.Id WHERE GeneroDescricao = @Genero", conn);
                cmd.Parameters.AddWithValue("@Genero", objFilter);
                dr = cmd.ExecuteReader();
                //lista vazia
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["GeneroDescricao"].ToString();
                    obj.Classificacao_Id = dr["ClassificacaoDescricao"].ToString();

                    //adicionar lista
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

        //busca por Id
        public FilmeDTO SearchId(int objSearch)
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand("SELECT * FROM filme WHERE filme.id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {

                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
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








        //carrega DDL(DropDawList)
        public List<GeneroDTO> CarregaDDL()
        {

            try
            {

                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>(); //lista vazia
                while (dr.Read())
                {
                    GeneroDTO obj = new GeneroDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.GeneroDescricao = dr["GeneroDescricao"].ToString();
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


        //CRUD - Insert
        public void Cadastrar(FilmeDTO objCad)
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO filme (Titulo,Produtora,UrlImg,Genero_Id,Classificacao_Id) VALUES (@Titulo,@Produtora,@UrlImg,@Genero_Id,@Classificacao_Id )", conn);
                cmd.Parameters.AddWithValue("@Titulo", objCad.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", objCad.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objCad.UrlImg);
                cmd.Parameters.AddWithValue("@Genero_Id", objCad.Genero_Id);
                cmd.Parameters.AddWithValue("@Classificacao_Id", objCad.Classificacao_Id);
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
        //CRUD - update
        public void Update(FilmeDTO objUpdt)
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Filme SET Titulo=@Titulo, Produtora=@Produtora, UrlImg=@UrlImg, Genero_Id=@GeneroDescricao, Classificacao_Id=@ClassificacaoDescricao WHERE Filme.Id= @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objUpdt.Id);
                cmd.Parameters.AddWithValue("@Titulo", objUpdt.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", objUpdt.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objUpdt.UrlImg);
                cmd.Parameters.AddWithValue("@GeneroDescricao", objUpdt.Genero_Id);
                cmd.Parameters.AddWithValue("@ClassificacaoDescricao", objUpdt.Classificacao_Id);

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
        //CRUD delete
        public void Delete(int objDel)
        {

            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Filme WHERE Filme.Id = @Id", conn);
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
