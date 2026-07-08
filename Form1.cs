using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaProducto
{
    public partial class Form1 : Form
    {
        //Inicializacion de un arreglo
        static string[] productos = { "Teclado", "Mouse", "Monitor", "Impresora", "Bocinas" };
        //Inicializamos total
        double Total = 0;
        // asignacion a un arrayList
        ArrayList aproductos = new ArrayList();
        //Inicializavion de la calse Ventas
        Ventas ObjVentas = new Ventas();
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblneto.Text = "0.00";
            MostrarFecha();
            MostrarHora();
            LimpiarControles();
            Llenacombo();
        }
        private void MostrarFecha()
        {
            lblfecha.Text = DateTime.Now.ToShortDateString();
        }
        private void MostrarHora()
        {
            lblhora.Text = DateTime.Now.ToShortTimeString();
        }
        private void LimpiarControles()
        {
            txtnombre.Clear();
            txtcantidad.Clear();
            cmbProducto.Text = "Selecciona un producto";
            lblprecio.Text = "0.00";
            txtnombre.Focus();
        }
        private void Llenacombo()
        {
            foreach (string p in productos)
            {
                cmbProducto.Items.Add(p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjVentas.Producto = cmbProducto.Text;
            lblprecio.Text = ObjVentas.AsignarPrecio().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enviar datos a la clase
            ObjVentas.Producto = cmbProducto.Text;
            ObjVentas.Cantidad = int.Parse(txtcantidad.Text);
            // Despues de enviar los valores invocamos de regreso los valores y usamos los metodos
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dataGridView1);

            fila.Cells[0].Value = ObjVentas.Producto.ToString();
            fila.Cells[1].Value = ObjVentas.Cantidad.ToString();
            fila.Cells[2].Value = ObjVentas.AsignarPrecio().ToString("C");
            fila.Cells[3].Value = ObjVentas.CalcularSubtotal().ToString("C");
            fila.Cells[4].Value = ObjVentas.CalcularDescuento().ToString("C");
            fila.Cells[5].Value = ObjVentas.CalcularNeto().ToString("C");

            //Llenamos la fila con los datos
            dataGridView1.Rows.Add(fila);

            //Actualizamos Total con cada producto que agreguemos
            Total += ObjVentas.CalcularNeto();
            lblneto.Text = Total.ToString("C");

            // Limpiamos los campos
            LimpiarControles();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseas salir del programa", "Sistema de ventas", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                LimpiarControles();
            }
        }
    }
}
