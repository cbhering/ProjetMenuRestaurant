using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExerciceRestoComposants
{
    public partial class Form2 : Form
    {
        internal enum ModeControl
        {
            INSERT , UPDATE
        }

        internal ModeControl Mode;

        internal TextBox TextBox1 { get => textBox1; }
        internal ComboBox ComboBox1 { get => comboBox1; }
        internal ComboBox ComboBox2 { get => comboBox2; }
        internal Button Button1 { get => button1; }

        private int n;       // le numéro de la commande

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out n))
            {
                comboBox1.DisplayMember = "Type_de_Composant";  
                comboBox1.ValueMember = "Type_de_Composant";
                //comboBox1.DataSource = Data.Commandes.TypeDeComposantDisponiblePourUnClient(n);
                comboBox1.DataSource = CoucheAffaires.Commandes.TypeDeComposantDisponiblePourUnClient(n);

                comboBox1.SelectedIndex = 0;
                if (comboBox1.Items.Count > 1) { comboBox1.Enabled = true; }
                else { comboBox1.Enabled = false; }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show("Numéro de commande doit être un nombre entier");
                    textBox1.Text = "";
                }
            }
           
        }

        internal void fillDropListComboBox2(String typeDeComposant)
        {
            comboBox2.DisplayMember = "Composant";
            comboBox2.ValueMember = "Num_du_Composant";
            comboBox2.DataSource = Donnees.Commandes.ComposantsDunTypeDeComposant(typeDeComposant);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                fillDropListComboBox2(comboBox1.SelectedValue.ToString());
                comboBox2.SelectedIndex = 0;
                comboBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool updated = false;
            if (Mode==ModeControl.INSERT)
            {
                updated = Donnees.Commandes.insererLignes(textBox1.Text,
                   comboBox1.SelectedValue.ToString(),
                   comboBox2.SelectedValue.ToString());

            }
            if (Mode==ModeControl.UPDATE)
            {
                updated = Donnees.Commandes.modifierLignes(textBox1.Text,
                   comboBox1.SelectedItem.ToString(),
                   comboBox2.SelectedValue.ToString());
            }      
               
            if (updated)
            {
                Program.MainForm.montrerCommandes();
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter / modifier");
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
