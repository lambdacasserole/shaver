using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaver
{
    class ShavianFontHelper
    {
        private static PrivateFontCollection fonts;
        private static string fontPath;

        public static FontFamily getFontFamily()
        {
            if (fonts == null)
            {
                fonts = new PrivateFontCollection();
                fontPath = Path.GetTempFileName();
                File.WriteAllBytes(fontPath, Properties.Resources.ANDAGII_);
                fonts.AddFontFile(fontPath);
            }
            return fonts.Families[0];
        }

        public static Font GetFont(float size)
        {
            return new Font(getFontFamily(), size);
        }
    }
}
