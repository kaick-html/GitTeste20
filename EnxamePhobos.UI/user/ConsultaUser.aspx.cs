using EnxamePhobos.DTO;//
using EnxamePhobos.BLL;//
using System;
using EnxamePhobos.UI.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.user
{
    public partial class ConsultaUser : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();


        //popular gridView
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarUsuario();
            gv1.DataBind();
        }





       


        protected void Page_Load(object sender, EventArgs e)
        {

            PopularGV();

        }

        















    }
}