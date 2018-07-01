﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {

        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            comboOperador.Text = "";
            lblResultado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador = comboOperador.Text;
            lblResultado.Text = Operar(num1, num2, operador).ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (lblResultado.Text.Length <  100)//limitacion para que el texto no se salga de pantalla
                {
                    double num = double.Parse(lblResultado.Text);
                    lblResultado.Text = Numero.DecimalBinario(num);
                }
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string verificacion = "";
            if (lblResultado.Text != "")
            {
                string num = lblResultado.Text;
                verificacion = Numero.BinarioDecimal(num);
                if (verificacion == "Valor invalido")
                {
                    MessageBox.Show("Valor Invalido","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                    lblResultado.Text = verificacion;
            }
        }

        private static double Operar(string num1, string num2, string operador)
        {
            double resultado = 0;
            Numero n1 = new Numero(num1);
            Numero n2 = new Numero(num2);
            Calculadora calc = new Calculadora();
            resultado = calc.Operar(n1, n2, operador);
            return resultado;
        }
    }
}
