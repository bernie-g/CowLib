using System.Drawing;
using System.IO;

namespace CowLib
{
    class Utils
    {
        public static void SaveFile(string text, string filePath, string fileName)
        {
            Directory.CreateDirectory(filePath);
            File.WriteAllText(Path.Combine(filePath, fileName), text);
        }
    }
}
