using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyectoSemestralBiblioteca.GlobalWeatherServicio;

namespace proyectoSemestralBiblioteca
{
    public partial class consumirServicio : System.Web.UI.Page
    {
  //      GlobalWeatherSoapClient servicio = new GlobalWeatherSoapClient("default");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
    //        Label1.Text = servicio.GetCitiesByCountry(TextBox1.Text);
        }
    }
}