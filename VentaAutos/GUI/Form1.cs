using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Mapper;
using Microsoft.VisualBasic;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BllVehiculo blVehiculo;
        List<BeVehiculo> lVehiculo;
        BllCliente blCliente;
        List<BeCliente> lCliente;
        private void Form1_Load(object sender, EventArgs e)
        {
            blVehiculo = new BllVehiculo();
            lVehiculo = blVehiculo.Consulta();
            blCliente = new BllCliente();
            lCliente = blCliente.Consulta();
            RefrescarVehiculos();
            RefrescarClientes();
        }

        private void btnAltaVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                //accedo al ultimo vehiculo(que va a ser el id más alto) y a ese código le sumas 1 
                //para sumar lo tengo que parsear a enterp (INT)
                //para guardarlo en código lo parseo a string 
                string _codigo = lVehiculo.Count > 0 ? (int.Parse(lVehiculo.Last().Codigo) + 1).ToString() : "1";
                string _patente = Interaction.InputBox("Patente:");
                string _marca = Interaction.InputBox("Marca:");
                string _modelo = Interaction.InputBox("Modelo:");
                string _año = Interaction.InputBox("Año:");
                decimal _precio = decimal.Parse(Interaction.InputBox("Precio:"));
                BeVehiculo a;
                if (rbVehiculoNormal.Checked)
                {
                    a = new BeNormal(_codigo, _patente, _marca, _modelo, _año, _precio, false, null);
                    blVehiculo.Alta(a);
                }
                else if(rbVehiculoCompetitivo.Checked)
                {
                    a = new BeCompetitivo(_codigo, _patente, _marca, _modelo, _año, _precio, false, null);
                    blVehiculo.Alta(a);
                }
                RefrescarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBajaVehiculo_Click(object sender, EventArgs e)
        {
            string _baja = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            BeVehiculo aux =  lVehiculo.Find(x => x.Codigo == _baja);
            blVehiculo.Baja(aux);
            RefrescarVehiculos();
        }

        private void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            string _baja = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            BeVehiculo aux = lVehiculo.Find(x => x.Codigo == _baja);
            string _patente = Interaction.InputBox("Patente:", "Modificando...", aux.Patente);
            string _marca = Interaction.InputBox("Marca:", "Modificando...", aux.Marca);
            string _modelo = Interaction.InputBox("Modelo:", "Modificando...", aux.Modelo);
            string _año = Interaction.InputBox("Año:", "Modificando...", aux.Año);
            decimal _precio = decimal.Parse(Interaction.InputBox("Precio:", "Modificando...", (aux.Precio).ToString()));
            _patente = aux.Patente;
            _marca = aux.Marca;
            _modelo = aux.Modelo;
            _año = aux.Año;
            _precio = aux.Precio;
            blVehiculo.Modificar(aux);
            RefrescarVehiculos();
        }
        public void RefrescarVehiculos()
        {
            dataGridView1.Rows.Clear();
            lVehiculo = blVehiculo.Consulta();
            foreach (BeVehiculo item in lVehiculo)
            {
                dataGridView1.Rows.Add(item.Codigo, item.Patente, item.Marca, item.Modelo, item.Año, item.Precio);
            }
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string _codigo = lCliente.Count > 0 ? (int.Parse(lCliente.Last().Codigo) + 1).ToString() : "1";
                string _nombre = Interaction.InputBox("Nombre:");
                string _apellido = Interaction.InputBox("Apellido:");
                string _dni = Interaction.InputBox("DNI:");
                BeCliente aux = new BeCliente(_codigo, _nombre, _apellido, _dni);
                blCliente.Alta(aux);
                lCliente = blCliente.Consulta();
                RefrescarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            string baja = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            BeCliente aux = lCliente.Find(x => x.Codigo == baja);
            blCliente.Baja(aux);
            RefrescarClientes();
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            string baja = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            BeCliente aux = lCliente.Find(x => x.Codigo == baja);
            string _nombre = Interaction.InputBox("Nombre:", aux.Nombre);
            string _apellido = Interaction.InputBox("Apellido:", aux.Apellido);
            string _dni = Interaction.InputBox("DNI:", aux.DNI);
            _nombre = aux.Nombre;
            _apellido = aux.Apellido;
            _dni = aux.DNI;
            blCliente.Modificar(aux);
            RefrescarClientes();
        }
        public void RefrescarClientes()
        {
            dataGridView2.Rows.Clear();
            lCliente = blCliente.Consulta();
            foreach (BeCliente item in lCliente)
            {
                dataGridView2.Rows.Add(item.Codigo, item.Nombre, item.Apellido, item.DNI);
            }
        }
    }
}
