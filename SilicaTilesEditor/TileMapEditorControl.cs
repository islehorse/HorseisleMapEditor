using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilicaTilesEditor
{
    public class TileMapEditorControl : Panel
    {
        public bool DisplayOverlay = true;
        public int ExtOverlay = 0;
        public int SelTileX = 0;
        public int SelTileY = 0;
        private int selectedTileX = 0;
        private int selectedTileY = 0;
        public TileMapEditorControl()
        {
            this.DoubleBuffered = true;
            this.VerticalScroll.SmallChange = 32;
            this.HorizontalScroll.SmallChange = 32;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int oldSelTileX = SelTileX;
            int oldSelTileY = SelTileY;

            int tinyOffsetX = (this.HorizontalScroll.Value % 32);
            int tinyOffsetY = (this.VerticalScroll.Value % 32);


            SelTileX = Convert.ToInt32(Math.Floor((float)(e.X + tinyOffsetX) / 32.0));
            SelTileY = Convert.ToInt32(Math.Floor((float)(e.Y + tinyOffsetY) / 32.0));

            selectedTileX = Convert.ToInt32(Math.Floor((float)HorizontalScroll.Value / 32.0)) + SelTileX;
            selectedTileY = Convert.ToInt32(Math.Floor((float)VerticalScroll.Value / 32.0)) + SelTileY;
            if (!(oldSelTileX == SelTileX && oldSelTileY == SelTileY))
            {

                if (e.Button == MouseButtons.Left)
                    OnMouseDown(e);

                this.Invalidate();
                if(Map.MapLoaded)
                    Program.form.lookingAt.Text = "Looking at: " + selectedTileX + "," + selectedTileY + "(" + Map.GetTileId(selectedTileX, selectedTileY, false) + ":" + Map.GetTileId(selectedTileX, selectedTileY, true) + ")";
            }

        }

        public void UpdateScroll()
        {
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Map.Width * 32, Map.Height * 32);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Map.SetTileId(selectedTileX, selectedTileY, DisplayOverlay, Program.form.tileSelector.SelectedTileid);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            g.Clear(Color.Blue);
            int offsetX = (this.HorizontalScroll.Value / 32);
            int offsetY = (this.VerticalScroll.Value / 32);

            int tinyOffsetX = (this.HorizontalScroll.Value % 32);
            int tinyOffsetY = (this.VerticalScroll.Value % 32);

            int tlistHeight = (this.Size.Height / 32)+ 1;
            int tlistWidth = (this.Size.Width / 32) + 1;
            int rH = this.Size.Height;
            int rW = this.Size.Width;
            int relX;
            int relY = 0;
            if (Map.MapLoaded)
            {

                for (int y = offsetY; y < (tlistHeight + offsetY)+1; y++)
                {
                    relX = -1;
                    for (int x = offsetX; x < (tlistWidth + offsetX)+1; x++)
                    {
                        relX++;
                        int tileId = Map.GetTileId(x, y, false) - 1;
                        Bitmap Tile = Tileset.TerrainList[tileId];
                        if (Tile == null)
                            continue;
                        g.DrawImageUnscaled(Tile, (relX * 32) - tinyOffsetX, (relY * 32) - tinyOffsetY);

                    }
                    relY++;
                }

                if (DisplayOverlay)
                {

                    relX = 0;
                    relY = 0;

                    for (int y = offsetY; y < (tlistHeight + offsetY) + 1; y++)
                    {
                        relX = -1;
                        for (int x = offsetX; x < (tlistWidth + offsetX) + 1; x++)
                        {
                            relX++;
                            int tileId = Map.GetTileId(x, y, true) - 1;
                            Bitmap Tile = null;
                            if (tileId >= Tileset.OverlayList.Length)
                            {
                                tileId -= Tileset.OverlayList.Length;
                                Tile = Tileset.GetTileset(ExtOverlay)[tileId];
                            }
                            else
                            {
                                Tile = Tileset.OverlayList[tileId];
                            }
                            if (Tile == null)
                                continue;
                            g.DrawImageUnscaled(Tile, (relX * 32) - tinyOffsetX, (relY * 32) - tinyOffsetY);

                        }
                        relY++;
                    }
                }
            }

            Pen p = new Pen(Color.Black);
            Pen wp = new Pen(Color.Aqua,3);
            for (int x = 0; x <= rW; x += 32)
                g.DrawLine(p, (x - tinyOffsetX), 0, (x - tinyOffsetX), rH);

            for (int y = 0; y <= rH; y += 32)
                g.DrawLine(p, 0, (y - tinyOffsetY), rW, (y - tinyOffsetY));

            // Highlight selected tile
            int exactX = (SelTileX*32) - tinyOffsetX;
            int exactY = (SelTileY*32) - tinyOffsetY;
            if(!DisplayOverlay)
                g.DrawRectangle(wp, exactX, exactY, 32, 32);
            else
                g.DrawRectangle(wp, exactX, exactY, 32, 48);

            g.Flush();
        }
    }
}
