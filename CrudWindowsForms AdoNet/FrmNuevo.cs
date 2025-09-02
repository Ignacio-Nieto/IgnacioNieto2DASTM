using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CrudWindowsForms_AdoNet.Usuario;

namespace CrudWindowsForms_AdoNet
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
        public FrmNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
                LoadData();
        }

        private void LoadData()
        {
            Usuario dbUsuario = new Usuario();
            Datos_Usuario usuario = dbUsuario.Get((int)Id);

            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtEmail.Text = usuario.Email;
            }
        }


        private void FrmNuevo_Load(object sender, EventArgs e)
        {
            
        }

private void button1_Click(object sender, EventArgs e)
{
    Usuario oUsuarioDb = new Usuario();
    try
    {
        if (Id == null)
            oUsuarioDb.Add(txtNombre.Text, txtEmail.Text);
        else
            oUsuarioDb.Update(txtNombre.Text, txtEmail.Text, Id.Value);

        this.Close();
    }
    catch (Exception ex)
    {
        throw new Exception("error" + ex.Message);
    }
}

    }
}
