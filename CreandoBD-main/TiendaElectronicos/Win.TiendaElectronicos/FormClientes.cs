﻿using BL.Tecnologia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TiendaElectronicos
{
    public partial class FormClientes : Form
    {

        ClientesBL _Clientes;
        public FormClientes()
        {
            InitializeComponent();

            _Clientes = new ClientesBL();
            clienteBindingSource.DataSource = _Clientes.ObtenerClientes();
        }

        private void clienteBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void addTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            clienteBindingSource.EndEdit();
            var cliente = (Cliente)clienteBindingSource.Current;

            var respuesta = _Clientes.GuardarCliente(cliente);

            if (respuesta.Exitoso == true)
            {
                clienteBindingSource.ResetBindings(false);
                DesahibilarHabilitar(true);
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _Clientes.AgregarCliente();
            clienteBindingSource.MoveLast();

            DesahibilarHabilitar(false);
        }

        private void DesahibilarHabilitar(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(idCustumerTextBox.Text != "")
            {
                var Id = Convert.ToInt32(idCustumerTextBox.Text);
                Eliminar(Id);
            }
            
        }

        private void Eliminar(int Id)
        {

            var Respuesta = _Clientes.EliminarCliente(Id);

            if (Respuesta== true)
            {
                clienteBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _Clientes.CancelarCambios();
            DesahibilarHabilitar(true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
