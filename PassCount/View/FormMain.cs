using PassCount.Config;
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
    public partial class FormMain : Form
    {
        public Root Raiz { get; set; }
        public String Path { get; set; }

        public AppConf Config { get; set; }

        public String Key { get; set; }

        public FormMain(AppConf appConf)
        {
            InitializeComponent();

            this.Raiz = new Root();
            this.Path = null;
            this.Config = appConf;
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void novaContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewItem newAccount = new FormNewItem(this, ItemType.Conta);
            newAccount.ShowDialog();
        }

        public void Reload()
        {
            comboBox1.Items.Clear();
            foreach (var Conta in this.Raiz.Contas)
            {
                comboBox1.Items.Add(Conta.Nome);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        public void Reload(ComboBox Combobox)
        {
            Combobox.Items.Clear();
            foreach (var Conta in this.Raiz.Contas)
            {
                Combobox.Items.Add(Conta.Nome);
            }

            if (Combobox.Items.Count > 0)
            {
                Combobox.SelectedIndex = 0;
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewItem key = new FormNewItem(this, ItemType.Salvar);
            key.ShowDialog();
        }

        public void Open(String Key, String Path)
        {
            try
            {
                this.Path = Path;
                this.Raiz = Raiz.Read(Path, Key);
                this.Key = Key;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Senha inválida");
            }
        }

        public void Save(String Key)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Security File|*.sec|AES File|*.aes|TXT File|*.txt";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                this.Path = saveFileDialog1.FileName;
                this.Raiz.Save(saveFileDialog1.FileName, Key);
                this.Key = Key;
            }
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Security File|*.sec";
            openFileDialog1.Title = "Select File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FormNewItem item = new FormNewItem(this, ItemType.Abrir, openFileDialog1.FileName);
                item.ShowDialog();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Raiz.Save(this.Path, this.Key);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems(comboBox1.SelectedIndex);
        }

        public void LoadItems(Int32 SelectedItem)
        {
            DataTable People = new DataTable("Contas");
            DataColumn c0 = new DataColumn("Nome");
            DataColumn c1 = new DataColumn("Valor");

            People.Columns.Add(c0);
            People.Columns.Add(c1);

            foreach (var Chave in Raiz.Contas[SelectedItem].Chaves)
            {
                DataRow row = People.NewRow();
                row["Nome"] = Chave.Nome;
                row["Valor"] = Chave.Valor;

                People.Rows.Add(row);
            }

            dataGridView1.DataSource = People;
        }

        private void novaChaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewKey key = new FormNewKey(this);
            key.ShowDialog();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 index = dataGridView1.CurrentCell.RowIndex;
                this.Raiz.Contas[comboBox1.SelectedIndex].Chaves.RemoveAt(index);
                LoadItems(comboBox1.SelectedIndex);
            }
            catch (Exception ex)
            {

            }
        }

        private void menuStartPage_Click(object sender, EventArgs e)
        {
            Utils.OpenPage(this.Config.startpage);
        }
    }
}
