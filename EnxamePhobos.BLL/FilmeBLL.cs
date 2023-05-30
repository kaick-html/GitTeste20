using EnxamePhobos.DAL;
using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EnxamePhobos.BLL
{
    public class FilmeBLL
    {
        //objeto para acessar todos os metodos da DAL
        FilmeDAL objBLL = new FilmeDAL();

        public List<FilmeDTO> ListarFilme()
        {
            return objBLL.Listar();
        }

        //filtrar filme por genero
        public List<FilmeDTO> FiltrarFIlmeBLL(string ObjFilter)
        {
            return objBLL.FiltrarFilme(ObjFilter);  
        }


        //busca por nome
        public FilmeDTO SearchFilmeBLL(string objSearch)
        {
            return objBLL.SearchFilme(objSearch);
        }

        //busca id
        public FilmeDTO SearchId(int objSearch)
        {
            return objBLL.SearchId(objSearch);
        }

        //carregar ddl
        public  List<GeneroDTO> CarregarDDlist()
        {
            return objBLL.CarregaDDL();
        }



        //cadastrar
        public void CadastrarFilme(FilmeDTO objCad)
        {

            objBLL.Cadastrar(objCad);

        }


        public void UpdateFilme(FilmeDTO objUpdt)
        {
            objBLL.Update(objUpdt);
        }

        public void DeleteFilme(int objDel)
        {

            objBLL.Delete(objDel);

        }



    }
}
