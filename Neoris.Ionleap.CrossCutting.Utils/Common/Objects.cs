﻿using System;
using System.Linq;

namespace Neoris.Ionleap.CrossCutting.Utils.Common
{
    public static class Objects
    {
        public static object CreateObjectByTypeName(string typeName)
        {
            // scan for the class type
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from t in assembly.GetTypes()
                where t.Name == typeName  // you could use the t.FullName aswel
                select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");

            return Activator.CreateInstance(type);
        }
    }
}