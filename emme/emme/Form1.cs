using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emme
{
    public partial class Form1 : Form
    {
        double precio = 0;
        double precioAceite = 0;
        double precioFinal = 0;
        double pago;
        public Form1()
        {
            InitializeComponent();
            AcceptButton = btnAceptar;
        }
      
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox del service
            
            cbService.Items.Add("Cambio de Aceite y Filtros");
            cbService.Items.Add("Service Completo");
            //comboBox del pago
            cbPago.Items.Add("Contado Efectivo");
            cbPago.Items.Add("Tarjeta");         
            //comboBox de tipos de aceite
            cbTipoAceite.Items.Add("Mineral-Total");
            cbTipoAceite.Items.Add("Semisint-Total");
            cbTipoAceite.Items.Add("Sintetico-Total");
            //fecha
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //precio
            lblPrecioFinal.Text = (0).ToString("C");
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            double gananciaFinal = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                gananciaFinal += Convert.ToDouble(item.SubItems[4].Text);        
            }
            MessageBox.Show($"la ganancia del dia es {gananciaFinal}");
        }

            
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string aceite = cbTipoAceite.Text;

            if (aceite.Equals("Mineral-Total")) precioAceite = 2000;
            if (aceite.Equals("Semisint-Total")) precioAceite = 3000;
            if (aceite.Equals("Sintetico-Total")) precioAceite = 5000;
            lblPrecioFinal.Text = precioAceite.ToString("C");


            double precioFinal;

            precioFinal = precio + precioAceite;

            lblPrecioFinal.Text = precioFinal.ToString("C");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecioFinal_Click(object sender, EventArgs e)
        {
            
        }

        private void cbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoDePago = cbPago.Text;
            double precioFinal;
            if (tipoDePago.Equals("Tarjeta")) pago = 10;
            if (tipoDePago.Equals("Contado Efectivo")) pago = 0;

            precioFinal = (precio + precioAceite);
            precioFinal = (pago * precioFinal) / 100 + precioFinal;
            lblPrecioFinal.Text = precioFinal.ToString("C");

        }

        private void cbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string servicio = cbService.Text;
            if (servicio.Equals("Cambio de Aceite")) precio = 5000;         
            if (servicio.Equals("Cambio de Aceite y Filtros")) precio = 1000;      
            if (servicio.Equals("Service Completo")) precio = 15000;
            lblPrecioFinal.Text = precio.ToString("C");

            double precioFinal;

            precioFinal = precio + precioAceite;

            lblPrecioFinal.Text = precioFinal.ToString("C");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                precioFinal += Convert.ToDouble(item.SubItems[4].Text);
                double gananciaFinal = precioFinal;
            }
            MessageBox.Show($"la ganancia del dia es {precioFinal}");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validacion 
            if (cbService.SelectedItem == null || cbTipoAceite.SelectedItem == null || cbPago.SelectedItem == null || textBox1.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
           

            string servicio = cbService.Text;
            string tipoDePago = cbPago.Text;
            string aceite = cbTipoAceite.Text;
            string cliente = textBox1.Text;
            string precioFinalLista = lblPrecioFinal.Text;

            // imprecion 

            if (cbService.SelectedItem != null && cbTipoAceite.SelectedItem != null && cbPago.SelectedItem != null && textBox1.Text != "")
            {
                ListViewItem lista = new ListViewItem(cliente);
                lista.SubItems.Add(servicio);
                lista.SubItems.Add(aceite);
                lista.SubItems.Add(tipoDePago);
                lista.SubItems.Add(precioFinalLista);
                listView1.Items.Add(lista);
            }
            
            // clear txt y combobox despues del aceptar
            textBox1.Clear();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            foreach (ListViewItem lista in listView1.SelectedItems)
            {
                lista.Remove();
            }

           
        }
    }

}
