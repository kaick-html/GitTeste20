using EnxamePhobos.DTO;
using EnxamePhobos.BLL;
using System;
using EnxamePhobos.UI.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageUser : System.Web.UI.Page
    {
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();

        //popular DropDawList
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.CarregaDDList();
            ddl1.DataBind();
        }


        //popular gridView
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarUsuario();
            gv1.DataBind();
        }


        //search by name
        public void Search()
        {
            string objSearch = txtSearch.Text;
            objModelo = objBLL.SearchByName(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtNome.Text = objModelo.Nome.ToString();
            txtEmail.Text = objModelo.Email.ToString();
            txtSenha.Text = objModelo.Senha.ToString();
            txtDtNasc.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objModelo.TipoUsuario_Id.ToString();



        }


        //carrega dados por Id
        public void CarregaDados()
        {
            int objSearch = int.Parse(txtId.Text);

            objModelo = objBLL.SearchById(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtNome.Text = objModelo.Nome.ToString();
            txtEmail.Text = objModelo.Email.ToString();
            txtSenha.Text = objModelo.Senha.ToString();
            txtDtNasc.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objModelo.TipoUsuario_Id.ToString();

        }







        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            PopularDDL1();
            PopularGV();
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


        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //passando a linha selecionada para a tela
            txtId.Text = gv1.SelectedRow.Cells[1].Text;
            CarregaDados();
            PopularDDL1();
        }

        //validation
        public bool ValidatePage()
        {

            bool validator;
            if (string.IsNullOrEmpty(txtNome.Text))
            {

                lblNome.Text = "Digite o Nome !!";
                txtNome.Focus();
                validator = false;

            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblEmail.Text = "Digite o Email !!";
                txtEmail.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblSenha.Text = "Digite a Senha !!";
                txtSenha.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtDtNasc.Text))
            {
                lblDtNasc.Text = "Digite a data de nascimento !!";
                txtDtNasc.Focus();
                validator = false;
            }
            else
            {

                validator = true;
            }
            return validator;


        }


        //CRUD - Insert/update
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if(ValidatePage())
            {

                //preenchendo dados
                objModelo = new UsuarioDTO();
                objModelo.Nome = txtNome.Text.Trim();
                objModelo.Email = txtEmail.Text.Trim();
                objModelo.Senha = txtSenha.Text.Trim();
                //ajustando data
                DateTime dt = DateTime.Parse(txtDtNasc.Text);
                objModelo.DataNascUsuario = dt;
                objModelo.TipoUsuario_Id = ddl1.SelectedValue;

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    objBLL.CadastrarUsuario(objModelo);
                    PopularGV();
                    lblMessage.Text = $"Usuário {objModelo.Nome} cadastrado com sucesso !!";
                }
                else
                {

                    objModelo.Id = int.Parse(txtId.Text);
                    objBLL.UpdateUser(objModelo);
                    PopularGV();
                    lblMessage.Text = $"usuário {objModelo.Nome} editado com sucesso!";

                }
            }
        }



        //CRUD delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            objModelo.Id = int.Parse(txtId.Text);
            objBLL.DeleteUser(objModelo.Id);
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











    }
}