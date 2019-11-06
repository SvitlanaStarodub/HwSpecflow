using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecflowHw.Helper
{
    public static class FileHelper
    {
        public static void SavePhoneDetailsToFile(List<string> characteristics)
        {
            File.WriteAllLines(Path.Join(Directory.GetCurrentDirectory(), "Char.txt"), characteristics);
        }
    }
}
