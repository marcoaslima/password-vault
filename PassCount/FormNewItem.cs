using PassCount.Model;
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
    public partial class FormNewItem : Form
    {
        public FormLogin Parent { get; set; }
        public ItemType Type { get; set; }
        public String Path { get; set; }

        public FormNewItem(FormLogin Parent, ItemType Type, String Path = null)
        {
            InitializeComponent();

            if (Type != ItemType.Conta)
            {
                txtNomeSenha.UseSystemPasswordChar = true;
                this.Text = "Digite a senha para prosseguir";
                this.label1.Text = "Senha requerida";
            }

            this.Parent = Parent;
            this.Type = Type;
            this.Path = Path;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            switch (this.Type)
            {
                case ItemType.Abrir:
                    this.Parent.Open(txtNomeSenha.Text, this.Path);
                    this.Parent.Reload();
                    this.Dispose();
                    break;
                case ItemType.Conta:
                    this.Parent.Raiz.Contas.Add(new Conta(txtNomeSenha.Text));
                    this.Parent.Reload();
                    this.Dispose();
                    break;
                case ItemType.Salvar:
                    this.Parent.Save(txtNomeSenha.Text);
                    this.Dispose();
                    break;
            }
            
        }
    }
}
