using Neoris.Ionleap.CrossCutting.Utils.IO;
using Neoris.Ionleap.CrossCutting.Utils.Serialization;
using System;
using System.IO;

namespace Neoris.Ionleap.CrossCutting.Infrastructure
{
    public class ProcessFile
    {
        private const string FolderName = "Settings";
        public static T Read<T>() where T : class
        {
            Type classInterfaceType = typeof(T);

            string filename = Paths.CurrentDirectory + FolderName + @"\" + classInterfaceType.Name + ".json";
            string json = File.ReadAllText(filename);
            return JsonSerializer<T>.DeSerialize(json);
        }
    }
}