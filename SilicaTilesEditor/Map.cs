using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SilicaTilesEditor
{
    public static class Map
    {
        public static string LoadedMap = "";
        public static bool MapLoaded = false;

        public static int Width;
        public static int Height;

        public static byte[] MapData;
        public static byte[] oMapData;
        public static void SetTileId(int x, int y, bool overlay, int tileId)
        {
            int pos = ((x * Height) + y);

            if (!MapLoaded)
                return;
            if ((pos <= 0 || pos >= oMapData.Length) && overlay)
                return;
            else if ((pos <= 0 || pos >= MapData.Length) && !overlay)
                return;
            else if (overlay)
                oMapData[pos] = (byte)tileId;
            else if (!overlay)
                MapData[pos] = (byte)tileId;
            else // Not sure how you could even get here.
                return;
        }
        public static int GetTileId(int x, int y, bool overlay)
        {
            int pos = ((x * Height) + y);

            if ((pos <= 0 || pos >= oMapData.Length) && overlay)
                return 1;
            else if ((pos <= 0 || pos >= MapData.Length) && !overlay)
                return 1;
            else if (overlay)
                return oMapData[pos];
            else if (!overlay)
                return MapData[pos];
            else // Not sure how you could even get here.
                return 1;
        }

        public static void OpenMap(string MapFile)
        {
            byte[] worldMap = File.ReadAllBytes(MapFile);

            Width = BitConverter.ToInt32(worldMap, 0);
            Height = BitConverter.ToInt32(worldMap, 4);

            MapData = new byte[Width * Height];
            oMapData = new byte[Width * Height];
            int ii = 8;

            for (int i = 0; i < MapData.Length; i++)
            {
                oMapData[i] = worldMap[ii];
                MapData[i] = worldMap[ii + 1];
                ii += 2;
            }

            worldMap = null;

            LoadedMap = MapFile;
            MapLoaded = true;
        }
    }
}
