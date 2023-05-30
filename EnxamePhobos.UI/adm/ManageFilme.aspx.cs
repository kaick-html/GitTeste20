using EnxamePhobos.BLL;
using EnxamePhobos.DTO;
using System;
using EnxamePhobos.UI.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageFilme : System.Web.UI.Page
    {

        FilmeDTO objModelo = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();


        //popular gridView
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarFilme();
            gv1.DataBind();
        }

        public void FiltrarGVFilme()
        {
            string objFilter = txtFiltro.Text;
            gv1.DataSource = objBLL.FiltrarFIlmeBLL(objFilter);
            gv1.DataBind();
        }

        //popular dropDaw
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.CarregarDDlist();
            ddl1.DataBind();
        }

        public void Search()
        {
            string objSearch = txtSearch.Text;

            objModelo = objBLL.SearchFilmeBLL(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtTitulo.Text = objModelo.Titulo.ToString();
            txtProdutora.Text = objModelo.Produtora.ToString();
            lblfUp1.Text = objModelo.UrlImg.ToString();
            lblClassificacao_Id.Text = objModelo.Classificacao_Id.ToString();
            ddl1.SelectedValue = objModelo.Genero_Id.ToString();
            txtSearch.Text = string.Empty;
            txtTitulo.Focus();



        }

        public void CarregaDados()
        {
            int objSearch = int.Parse(txtId.Text);

            objModelo = objBLL.SearchId(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtTitulo.Text = objModelo.Titulo.ToString();
            txtProdutora.Text = objModelo.Produtora.ToString();
            lblfUp1.Text = objModelo.UrlImg.ToString();
            lblClassificacao_Id.Text = objModelo.Classificacao_Id.ToString();
            ddl1.SelectedValue = objModelo.Genero_Id.ToString();


        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                txtId.Enabled = false;
                PopularGV();
                PopularDDL1();
            }
            
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //passando a linha selecionada para a tela
            txtId.Text = gv1.SelectedRow.Cells[1].Text;
            CarregaDados();
            PopularDDL1();
        }

        public bool ValidatePage()
        {

            bool validator;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {

                lblTitulo.Text = "Digite o titulo !!";
                txtTitulo.Focus();
                validator = false;

            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite a produtora !!";
                txtProdutora.Focus();
                validator = false;
            }

            else if (string.IsNullOrEmpty(lblClassificacao_Id.Text))
            {
                lblClassificacao_Id.Text = "Selecione a Classificação !!";
                rbl1.Focus();
                validator = false;
            }

            //else if (string.IsNullOrEmpty(lblDDL.Text))
            //{
            //    lblDDL.Text = "Digite o gênero !!";
            //    ddl1.Focus();
            //    validator = false;
            //}
            
            else
            {

                validator = true;
            }
            return validator;


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                lblSearch.Text = "Digite a busca!";
                txtSearch.Focus();
                return;

            }
            Search();
            lblSearch.Text = string.Empty;


        }


        //CRUD - Insert/update
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {

                //preenchendo dados
                objModelo = new FilmeDTO();
                objModelo.Titulo = txtTitulo.Text.Trim();
                objModelo.Produtora = txtProdutora.Text.Trim();
                

                //imagem
                //cadastrando imagens
                if (fUp1.HasFile)
                {
                    string str = fUp1.FileName;
                    fUp1.PostedFile.SaveAs(Server.MapPath("~/resource/img/" + str));
                    string CaminhoImg = "~/resource/img/" + str.ToString();
                    objModelo.UrlImg = CaminhoImg;
                }
                else
                {
                    lblMessage.Text = "Deu Merda !!";
                }

                //radio button
                objModelo.Classificacao_Id = rbl1.SelectedValue;
                //genero
                objModelo.Genero_Id = ddl1.SelectedValue;

                //objBLL.CadastrarFilme(objModelo);
                //PopularGV();
                //lblMessage.Text = $"Filme {objModelo.Titulo} cadastrado com sucesso!";


                if (string.IsNullOrEmpty(txtId.Text))
                {
                    objBLL.CadastrarFilme(objModelo);
                    PopularGV();
                    Limpar.ClearControl(this);
                    lblMessage.Text = $"Usuário {objModelo.Titulo} cadastrado com sucesso !!";
                    txtSearch.Focus();
                }
                else
                {

                    objModelo.Id = int.Parse(txtId.Text);
                    objBLL.UpdateFilme(objModelo);
                    PopularGV();
                    Limpar.ClearControl(this);
                    lblMessage.Text = $"usuário {objModelo.Titulo} editado com sucesso!";
                    txtSearch.Focus();

                }

            }
        }

        //CRUD delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            objModelo.Id = int.Parse(txtId.Text);
            objBLL.DeleteFilme(objModelo.Id);
            PopularGV();
            Limpar.ClearControl(this);

        }

        //clear
        protected void btnLimpar_Click(object sender, EventArgs e)
        {

            PopularGV();
            Limpar.ClearControl(this);
            txtSearch.Focus();

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
           string objFilter = txtFiltro.Text;
           var result = objBLL.FiltrarFIlmeBLL(objFilter);
            if (string.IsNullOrEmpty(txtFiltro.Text) || (result.Count == 0))
            {
                lblFiltro.ForeColor = System.Drawing.Color.White;
                Limpar.ClearControl(this);
                lblFiltro.Text = "Digite um gênero existente !!";
                txtFiltro.Focus();
                PopularGV();
            }
            else
            {
                FiltrarGVFilme();
                Limpar.ClearControl(this);
                txtFiltro.Focus();
            }

        }
    }
}