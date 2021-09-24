using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilicaTilesEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newItem_Click(object sender, EventArgs e)
        {

        }

        private void loadItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDg = new OpenFileDialog();
            loadFileDg.Filter = "Map Data Files|*.MAP";
            loadFileDg.Title = "Select Map File";
            if(loadFileDg.ShowDialog() == DialogResult.OK)
            {
                Map.OpenMap(loadFileDg.FileName);
                tileList.UpdateScroll();
                tileList.Invalidate();

            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Tileset.ReadTerrain();
            Tileset.ReadOverlay();
            Tileset.ReadExtOverlay();
            layout.ColumnStyles[0].Width = (32*7) + SystemInformation.VerticalScrollBarWidth;
            tileset0.Checked = true;
            tileList.ExtOverlay = 0;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
        }

        private void overlayLayerOption_Click(object sender, EventArgs e)
        {
            tileList.DisplayOverlay = overlayLayerOption.Checked;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();
        }

        private void UncheckAll()
        {
            tileset0.Checked = false;
            tileset1.Checked = false;
            tileset2.Checked = false;
            tileset3.Checked = false;
            tileset4.Checked = false;
            tileset5.Checked = false;
            tileset6.Checked = false;
            tileset7.Checked = false;
        }
        private void tileset0_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset0.Checked = true;
            tileList.ExtOverlay = 0;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();
            
        }

        private void tileset1_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset1.Checked = true;
            tileList.ExtOverlay = 1;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset2_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset2.Checked = true;
            tileList.ExtOverlay = 2;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset3_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset3.Checked = true;
            tileList.ExtOverlay = 3;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset4_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset4.Checked = true;
            tileList.ExtOverlay = 4;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset5_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset5.Checked = true;
            tileList.ExtOverlay = 5;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset6_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset6.Checked = true;
            tileList.ExtOverlay = 6;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

        private void tileset7_Click(object sender, EventArgs e)
        {
            UncheckAll();
            tileset7.Checked = true;
            tileList.ExtOverlay = 7;
            tileSelector.CalculateScroll();
            tileSelector.Invalidate();
            tileList.Invalidate();

        }

    }
}
