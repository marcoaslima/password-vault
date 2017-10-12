using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PassCount
{
    public partial class FormNewKey : Form
    {
        public FormMain Parent { get; set; }

        public FormNewKey(FormMain Parent)
        {
            InitializeComponent();
            this.Parent = Parent;

            this.Parent.Reload(this.comboBox1);
            this.comboBox1.SelectedIndex = this.Parent.comboBox1.SelectedIndex;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.Parent.Raiz.Contas[comboBox1.SelectedIndex].Chaves.Add(new Model.Chave(txtChave.Text, txtValor.Text));
            this.Parent.LoadItems(this.Parent.comboBox1.SelectedIndex);
            this.Dispose();
        }
    }
}
