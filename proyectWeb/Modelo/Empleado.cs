using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace Modelo
{
    public class Empleado
    {
        ConexionBD conectar = new ConexionBD();
        
        private DataTable drop_puesto()
        {
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string consulta = string.Format("Select id_puesto id, puesto from puestos;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        private DataTable grid_empleados()
        {
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string consulta = string.Format("Select e.id_empleado id, e.codigo, e.nombres, e.apellidos, e.direccion, " +
                "e.telefono, e.telefono, e.fecha_nacimiento, p.puesto, e.id_puesto  \r\nfrom empleados e\r\ninner join puestos " +
                "p on e.id_puesto = p.id_puesto;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            return tabla;
        }

        public void drop_empleados(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void grid_empleados(GridView grid)
        {
             grid.DataSource = grid_empleados();
            grid.DataBind();
        }

        public int crear(string codigo, string nombres, string apelllidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("INSERT INTO empleados (codigo, nombres, apellidos, direccion, telefono, fecha_nacimiento, id_puesto) " +
                "\r\nVALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6})",codigo,nombres,apelllidos,direccion,telefono,fecha,id_puesto);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }

        public int actualizar(int id, string codigo, string nombres, string apelllidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("UPDATE empleados SET codigo='{0}', nombres='{1}', apellidos='{2}', direccion='{3}', telefono='{4}', fecha_nacimiento='{5}', id_puesto={6} " +
                "\r\nWHERE id_empleado ={7}", codigo, nombres, apelllidos, direccion, telefono, fecha, id_puesto, id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }

        public int borrar(int id)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("DELETE FROM empleados WHERE id_empleado ={0}", id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }



    }
}
