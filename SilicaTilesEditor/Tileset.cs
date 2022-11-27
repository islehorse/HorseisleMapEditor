using SilicaTilesEditor.Properties;
using System;
using System.Drawing;

namespace SilicaTilesEditor
{
    class Tileset
    {
        public static Bitmap[] TerrainList = new Bitmap[((Resources.TerrainTileset.Height / 32) * (Resources.TerrainTileset.Width / 32)) + 1];
        public static Bitmap[] OverlayList = new Bitmap[192 + 1];
        public static Bitmap[] ExtOverlays = new Bitmap[8] { Resources.Tileset0, Resources.Tileset1, Resources.Tileset2, Resources.Tileset3, Resources.Tileset4, Resources.Tileset5, Resources.Tileset6, Resources.Tileset7 };

        public static Bitmap[] ExtNorm = new Bitmap[((Resources.Tileset0.Height / 48) * (Resources.Tileset0.Width / 32))];
        public static Bitmap[] ExtSnow = new Bitmap[((Resources.Tileset1.Height / 48) * (Resources.Tileset1.Width / 32))];
        public static Bitmap[] ExtSand = new Bitmap[((Resources.Tileset2.Height / 48) * (Resources.Tileset2.Width / 32))];
        public static Bitmap[] ExtPirt = new Bitmap[((Resources.Tileset3.Height / 48) * (Resources.Tileset3.Width / 32))];
        public static Bitmap[] ExtFlwr = new Bitmap[((Resources.Tileset4.Height / 48) * (Resources.Tileset4.Width / 32))];
        public static Bitmap[] ExtJngl = new Bitmap[((Resources.Tileset5.Height / 48) * (Resources.Tileset5.Width / 32))];
        public static Bitmap[] ExtClwd = new Bitmap[((Resources.Tileset6.Height / 48) * (Resources.Tileset6.Width / 32))];
        public static Bitmap[] ExtVolc = new Bitmap[((Resources.Tileset7.Height / 48) * (Resources.Tileset7.Width / 32))];

        public static Bitmap[] JoinedTileset
        {
            get
            {
                Bitmap[] ExtOverlaySet = GetTileset(Program.form.tileList.ExtOverlay);
                int sz = OverlayList.Length + ExtOverlaySet.Length;
                if (sz > 0xFF)
                    sz = 0xFF;
                Bitmap[] arr = new Bitmap[sz];
                int i = 0;
                for(i = 0; i < OverlayList.Length; i++)
                {
                    arr[i] = OverlayList[i];
                }
                for (int ii = 0; ii < ExtOverlaySet.Length; ii++)
                {
                    arr[i] = ExtOverlaySet[ii];
                    i++;
                    if (i >= 0xFF)
                        break;
                }
                return arr;
            }
        }

        public static Boolean ReadAllTerrain = false;
        public static Boolean ReadAllOverlay = false;
        public static void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        public static Bitmap[] GetTileset(int numb)
        {
            switch(numb)
            {
                case 0:
                    return ExtNorm;
                case 1:
                    return ExtSnow;
                case 2:
                    return ExtSand;
                case 3:
                    return ExtPirt;
                case 4:
                    return ExtFlwr;
                case 5:
                    return ExtJngl;
                case 6:
                    return ExtClwd;
                case 7:
                    return ExtVolc;
                default:
                    return ExtNorm;
            }
        }

        public static void ReadTerrain()
        {
            Console.WriteLine("Reading Terrain.png...");
            int i = 0;
            Rectangle dstRect = new Rectangle(0, 0, 32, 32);
            Rectangle srcRect = new Rectangle(0, 0, 32, 32);

            for (int y = 0; y < (Resources.TerrainTileset.Height/32); y++)
            {
                for (int x = 0; x < (Resources.TerrainTileset.Width / 32); x++)
                {
                    i++;
                    TerrainList[i] = new Bitmap(32, 32);
                    srcRect.X = x * 32;
                    srcRect.Y = y * 32;
                    CopyRegionIntoImage(Resources.TerrainTileset, srcRect, TerrainList[i], dstRect);
                }
            }
            ReadAllTerrain = true;
        }

        public static void ReadExtOverlay()
        {
            Rectangle dstRect = new Rectangle(0, 0, 32, 48);
            Rectangle srcRect = new Rectangle(0, 0, 32, 48);
            for (int picid = 0; picid <= 7; picid++)
            {
                Bitmap[] TilesetList = GetTileset(picid);
                Bitmap Tileset = ExtOverlays[picid];

                Console.WriteLine("Reading Overlay"+ picid.ToString()+".png...");
                int i = 0;

                for (int y = 0; y < (Tileset.Height / 48); y++)
                {
                    for (int x = 0; x < (Tileset.Width / 32); x++)
                    {
                        TilesetList[i] = new Bitmap(32, 48);
                        srcRect.X = x * 32;
                        srcRect.Y = y * 48;
                        CopyRegionIntoImage(Tileset, srcRect, TilesetList[i], dstRect);
                        i++;
                    }
                }
                Console.WriteLine("Total Tiles Read: " + i.ToString());
            }
        }
        public static void ReadOverlay()
        {
            Console.WriteLine("Reading Overlay.png...");
            int i = 0;
            int OVERLAY_SIZE = 24;

            Rectangle dstRect = new Rectangle(0, 0, 32, 48);
            Rectangle srcRect = new Rectangle(0, 0, 32, 48);

            for (int y = 0; y < OVERLAY_SIZE; y++)
            {
                for (int x = 0; x < (Resources.OverlayTileset.Width / 32); x++)
                {
                    i++;
                    OverlayList[i] = new Bitmap(32, 48);
                    srcRect.X = x * 32;
                    srcRect.Y = y * 48;

                    CopyRegionIntoImage(Resources.OverlayTileset, srcRect, OverlayList[i], dstRect);
                }
            }
        }
    }
}
