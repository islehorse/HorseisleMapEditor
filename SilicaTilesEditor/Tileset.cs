using SilicaTilesEditor.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SilicaTilesEditor
{
    class Tileset
    {
        private static Bitmap cacheTerrainTileset = Resources.TerrainTileset;
        private static Bitmap cacheOverlayTileset = Resources.OverlayTileset;
        private static Bitmap cacheOverlayTileset0 = Resources.Tileset0;
        private static Bitmap cacheOverlayTileset1 = Resources.Tileset1;
        private static Bitmap cacheOverlayTileset2 = Resources.Tileset2;
        private static Bitmap cacheOverlayTileset3 = Resources.Tileset3;
        private static Bitmap cacheOverlayTileset4 = Resources.Tileset4;
        private static Bitmap cacheOverlayTileset5 = Resources.Tileset5;
        private static Bitmap cacheOverlayTileset6 = Resources.Tileset6;
        private static Bitmap cacheOverlayTileset7 = Resources.Tileset7;


        public static Bitmap[] TerrainList = new Bitmap[((cacheTerrainTileset.Height / 32) * (cacheTerrainTileset.Width / 32)) + 1];
        public static Bitmap[] OverlayList = new Bitmap[192 + 1];
        public static Bitmap[] ExtOverlays = new Bitmap[8] { cacheOverlayTileset0, cacheOverlayTileset1, cacheOverlayTileset2, cacheOverlayTileset3, cacheOverlayTileset4, cacheOverlayTileset5, cacheOverlayTileset6, cacheOverlayTileset7 };

        public static Bitmap[] ExtNorm = new Bitmap[((cacheOverlayTileset0.Height / 48) * (cacheOverlayTileset0.Width / 32))];
        public static Bitmap[] ExtSnow = new Bitmap[((cacheOverlayTileset1.Height / 48) * (cacheOverlayTileset1.Width / 32))];
        public static Bitmap[] ExtSand = new Bitmap[((cacheOverlayTileset2.Height / 48) * (cacheOverlayTileset2.Width / 32))];
        public static Bitmap[] ExtPirt = new Bitmap[((cacheOverlayTileset3.Height / 48) * (cacheOverlayTileset3.Width / 32))];
        public static Bitmap[] ExtFlwr = new Bitmap[((cacheOverlayTileset4.Height / 48) * (cacheOverlayTileset4.Width / 32))];
        public static Bitmap[] ExtJngl = new Bitmap[((cacheOverlayTileset5.Height / 48) * (cacheOverlayTileset5.Width / 32))];
        public static Bitmap[] ExtClwd = new Bitmap[((cacheOverlayTileset6.Height / 48) * (cacheOverlayTileset6.Width / 32))];
        public static Bitmap[] ExtVolc = new Bitmap[((cacheOverlayTileset7.Height / 48) * (cacheOverlayTileset7.Width / 32))];
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

        public static void ReadAllTiles()
        {
            Task[] tileTasks = new Task[3];

            tileTasks[0] = Task.Run(() => readTerrain());
            tileTasks[1] = Task.Run(() => readOverlay());
            tileTasks[2] = Task.Run(() => readExtOverlay());

            Task.WaitAll(tileTasks);
            ReadAllTerrain = true;
            ReadAllOverlay = true;
        }
        private static void readTerrain()
        {
            Console.WriteLine("Reading Terrain.png...");
            int i = 0;
            Rectangle dstRect = new Rectangle(0, 0, 32, 32);
            Rectangle srcRect = new Rectangle(0, 0, 32, 32);

            for (int y = 0; y < (cacheTerrainTileset.Height/32); y++)
            {
                for (int x = 0; x < (cacheTerrainTileset.Width / 32); x++)
                {
                    i++;
                    TerrainList[i] = new Bitmap(32, 32);
                    srcRect.X = x * 32;
                    srcRect.Y = y * 32;
                    CopyRegionIntoImage(cacheTerrainTileset, srcRect, TerrainList[i], dstRect);
                }
            }
        }

        private static void readExtOverlay()
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
        private static void readOverlay()
        {
            Console.WriteLine("Reading Overlay.png...");
            int i = 0;
            int OVERLAY_SIZE = 24;

            Rectangle dstRect = new Rectangle(0, 0, 32, 48);
            Rectangle srcRect = new Rectangle(0, 0, 32, 48);

            for (int y = 0; y < OVERLAY_SIZE; y++)
            {
                for (int x = 0; x < (cacheOverlayTileset.Width / 32); x++)
                {
                    i++;
                    OverlayList[i] = new Bitmap(32, 48);
                    srcRect.X = x * 32;
                    srcRect.Y = y * 48;

                    CopyRegionIntoImage(cacheOverlayTileset, srcRect, OverlayList[i], dstRect);
                }
            }
        }
    }
}
