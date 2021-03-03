using System;
using System.Collections.Generic;
using System.Text;

namespace Neoris.Ionleap.CrossCutting.Utils.IO
{
    public static class Paths
    {
        public static string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;
    }
}
