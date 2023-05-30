using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.Utilities
{
    public static class Limpar
    {

        public static void ClearControl(Control ctrl)
        {

            foreach (Control c in ctrl.Controls)
            {

                if (c is TextBox) 
                {

                    ((TextBox)c).Text = string.Empty;

                }
                else if (c is Label)
                {
                
                    ((Label)c).Text = string.Empty;
                
                }
                ClearControl(c);

            }

        }
















    }
}