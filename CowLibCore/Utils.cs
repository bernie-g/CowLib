// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Collections.Generic;
using System.IO;

namespace CowLibCore
{
    internal class Utils
    {
        public static void SaveFile(string text, string filePath, string fileName)
        {
            Directory.CreateDirectory(filePath);
            File.WriteAllText(Path.Combine(filePath, fileName), text);
        }

        public static string GetUniqueName<T>(string desiredName, Dictionary<string, T> dictionary)
        {
            if (!dictionary.ContainsKey(desiredName)) return desiredName;
            
            for (int i = 1; i < 99999999; i++) {
                if (!dictionary.ContainsKey(desiredName + "_" + i)) return desiredName;
            }

            return "If_You_See_This_Then_You_Fucked_Up";
        }
    }
}