using EnxamePhobos.DTO;
using EnxamePhobos.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.user
{
    public partial class ConsultaFilme : System.Web.UI.Page
    {

        FilmeBLL objBLL = new FilmeBLL();

        //popular gridView
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarFilme();
            gv1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGV();
        }
    }
}