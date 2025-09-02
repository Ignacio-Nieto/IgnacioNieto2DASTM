using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsForms_AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Refresh()
        {
            Usuario usuarioDB = new Usuario();
            dataGridView1.DataSource = usuarioDB.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNuevo frm = new FrmNuevo();
            frm.ShowDialog();
            Refresh();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch { return null; }
           
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null){
                FrmNuevo frmEdit = new FrmNuevo(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            try
            {
                if (Id != null)
                {
                    Usuario oUsuarioDB = new Usuario();
                    oUsuarioDB.Delete((int)Id);
                    Refresh();
                }
            }
            catch(Exception ex) { throw new Exception("error" + ex.Message); }
        }
    }
}