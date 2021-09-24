using System;
using System.Windows.Forms;

namespace SilicaTilesEditor
{
    public partial class NewMapForm : Form
    {
        public NewMapForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void createMap_Click(object sender, EventArgs e)
        {
            Map.CreateMap(Convert.ToInt32(widthUpDown.Value), Convert.ToInt32(heightUpDown.Value));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
