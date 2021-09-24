using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilicaTilesEditor
{
    public class TileSelectorControl : Panel
    {
        public TileSelectorControl()
        {
            this.DoubleBuffered = true;
        }
        int SelTileX = 0;
        int SelTileY = 0;
        public int SelectedTileid = 1;
        protected override void OnMouseClick(MouseEventArgs e)
        {
            int rW = (this.Size.Width - SystemInformation.VerticalScrollBarWidth);

            int maxX = (rW / 32)+1;


            int oldSelTileX = SelTileX;
            int oldSelTileY = SelTileY;

            int tinyOffsetY = (this.VerticalScroll.Value % 32);
            if (Program.form.tileList.DisplayOverlay)
                tinyOffsetY = (this.VerticalScroll.Value % 48);

            SelTileX = Convert.ToInt32(Math.Floor((float)e.X / 32.0));
            if (!Program.form.tileList.DisplayOverlay)
                SelTileY = Convert.ToInt32(Math.Floor((float)VerticalScroll.Value / 32.0)) + Convert.ToInt32(Math.Floor((float)(e.Y + tinyOffsetY) / 32.0));
            else
                SelTileY = Convert.ToInt32(Math.Floor((float)VerticalScroll.Value / 48.0)) + Convert.ToInt32(Math.Floor((float)(e.Y + tinyOffsetY) / 48.0));

            SelectedTileid = ((SelTileY * maxX) + SelTileX) + 1;

            bool change = false;
            if(SelectedTileid > 0xFF)
            {
                SelectedTileid = 0xFF;
                change = true;
            }

            if(!Program.form.tileList.DisplayOverlay)
            {
                if(SelectedTileid > Tileset.TerrainList.Length)
                {
                    SelectedTileid = Tileset.TerrainList.Length;
                    change = true;
                }
            }
            else
            {
                if (SelectedTileid > Tileset.JoinedTileset.Length)
                {
                    SelectedTileid = Tileset.JoinedTileset.Length;
                    change = true;
                }
            }

            if (change)
            {
                SelTileX = (SelectedTileid % maxX) - 1;
                SelTileY = SelectedTileid / maxX;
            }
            if (!(oldSelTileX == SelTileX && oldSelTileY == SelTileY))
            {
                Program.form.selTileId.Text = "Seleted Tile ID: " + SelectedTileid;
                this.Invalidate();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
        }
        public void CalculateScroll()
        {
            int rW = (this.Size.Width - SystemInformation.VerticalScrollBarWidth);

            int x = 0;
            int y = 0;
            int maxX = rW / 32;

            Bitmap[] tileset = Tileset.TerrainList;
            if (Program.form.tileList.DisplayOverlay)
                tileset = Tileset.JoinedTileset;

            int addFinal = tileset.Length % maxX;

            int tilewidth = 32;
            int tileheight = 32;
            if (Program.form.tileList.DisplayOverlay)
                tileheight = 48;


            for (int i = 0; i < tileset.Length; i++)
            {
                Bitmap tile = tileset[i];

                if (tile != null)
                {
                    tilewidth = tile.Width;
                    tileheight = tile.Height;
                }
                x += tilewidth;

                if (x > (maxX * tilewidth))
                {
                    x = 0;
                    y += tileheight;
                }

            }
            if (addFinal != 0)
                y += tileheight;

            AutoScroll = false;
            AutoScrollMinSize = new Size(0, y);
            AutoScroll = true;


            if (Program.form.tileList.DisplayOverlay)
                VerticalScroll.SmallChange = 32;
            else
                VerticalScroll.SmallChange = 48;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!Program.form.tileList.DisplayOverlay)
                g.Clear(Color.Blue);
            else
                g.Clear(Color.Magenta);


            int rH = this.Size.Height;
            int rW = (this.Size.Width - SystemInformation.VerticalScrollBarWidth);

            int offsetY = (this.VerticalScroll.Value / 32);
            int tinyOffsetY = (this.VerticalScroll.Value % 32);
            if (Program.form.tileList.DisplayOverlay)
            {
                offsetY = (this.VerticalScroll.Value / 48);
                tinyOffsetY = (this.VerticalScroll.Value % 48);
            }
            int x = 0;
            int y = 0;
            int maxX = rW / 32;
            int window = (offsetY * (maxX + 1));
            
            Bitmap[] tileset = Tileset.TerrainList;
            if (Program.form.tileList.DisplayOverlay)
                tileset = Tileset.JoinedTileset;

            for (int i = window; i < tileset.Length; i++)
            {

                int tilewidth = 32;
                int tileheight = 32;
                if (Program.form.tileList.DisplayOverlay)
                    tileheight = 48;

                Bitmap tile = tileset[i];

                if(tile != null)
                {
                    g.DrawImageUnscaled(tile, x, y - tinyOffsetY);
                    tilewidth = tile.Width;
                    tileheight = tile.Height;
                }
                x += tilewidth;
                
                if(x > (maxX*tilewidth))
                {
                    x = 0;
                    y+=tileheight;
                }

            }



            Pen p = new Pen(Color.Black);
            Pen wp = new Pen(Color.Aqua, 3);
            for (x = 0; x <= rW; x += 32)
                g.DrawLine(p, x, 0, x, rH);

            if (!Program.form.tileList.DisplayOverlay)
            {
                for (y = 0; y <= rH; y += 32)
                    g.DrawLine(p, 0, (y - tinyOffsetY), rW, (y - tinyOffsetY));
            }
            else
            {
                for (y = 0; y <= rH; y += 48)
                    g.DrawLine(p, 0, (y - tinyOffsetY), rW, (y - tinyOffsetY));

            }

            // Highlight selected tile
            int exactX = (SelTileX * 32);
            int exactY = 0;
            if (!Program.form.tileList.DisplayOverlay)
                exactY = (SelTileY * 32) - VerticalScroll.Value;
            else
                exactY = (SelTileY * 48) - VerticalScroll.Value;

            if (!Program.form.tileList.DisplayOverlay)
                g.DrawRectangle(wp, exactX, exactY, 32, 32);
            else
                g.DrawRectangle(wp, exactX, exactY, 32, 48);
        }
    }
}
