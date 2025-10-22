using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectWeb
{
    public partial class Empleados : System.Web.UI.Page
    {

        Empleado empleado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empleado = new Empleado();
                empleado.drop_empleados(Drop_puesto);
                empleado.grid_empleados(Grid_Empleados);

            }

        }

        protected void Btn_crear_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            int no = 0;

            no = empleado.crear(Txt_codigo.Text, Txt_Nombres.Text, Txt_apellido.Text, Txt_direccion.Text, Txt_telefono.Text, Txt_fechaN.Text, Convert.ToInt32(Drop_puesto.SelectedValue));

            if (no > 0)
            {
                Lbl_Mensaje.Text = "Ingreso Exitoso...";
                empleado.grid_empleados(Grid_Empleados);
            }

        }

        protected void Grid_Empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_codigo.Text = Grid_Empleados.SelectedRow.Cells[2].Text;
            Txt_Nombres.Text = Grid_Empleados.SelectedRow.Cells[3].Text;
            Txt_apellido.Text = Grid_Empleados.SelectedRow.Cells[4].Text;
            Txt_direccion.Text = Grid_Empleados.SelectedRow.Cells[5].Text;
            Txt_telefono.Text = Grid_Empleados.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(Grid_Empleados.SelectedRow.Cells[7].Text);
            Txt_fechaN.Text = fecha.ToString("yyyy-MM-dd");
            int indice = Grid_Empleados.SelectedRow.RowIndex;
            Drop_puesto.SelectedValue = Grid_Empleados.DataKeys[indice].Values["id_puesto"].ToString();
            Btn_actualizar.Visible = true;
        }

        protected void Grid_Empleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            empleado = new Empleado();
            int no = 0;

            no = empleado.borrar(Convert.ToInt32(e.Keys["id"]));

            if (no > 0)
            {
                Lbl_Mensaje.Text = "Borrado Exitoso...";
                empleado.grid_empleados(Grid_Empleados);
            }
        }

        protected void Btn_actualizar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            int no = 0;

            no = empleado.actualizar(Convert.ToInt32(Grid_Empleados.SelectedValue),Txt_codigo.Text, Txt_Nombres.Text, Txt_apellido.Text, Txt_direccion.Text, Txt_telefono.Text, Txt_fechaN.Text, Convert.ToInt32(Drop_puesto.SelectedValue));

            if (no > 0)
            {
                Lbl_Mensaje.Text = "Modificación Exitosa...";
                empleado.grid_empleados(Grid_Empleados);
            }
        }
    }
}