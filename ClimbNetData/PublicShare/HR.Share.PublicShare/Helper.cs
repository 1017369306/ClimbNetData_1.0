using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.Share.PublicShare
{
    public class Helper
    {
        public static object GetIntanceFormAssembly(string assembly,Type type)
        {
            Type objType = GetTypeFormAssembly(assembly, type);
            if (objType == null) return null;
            try
            {
                return Activator.CreateInstance(objType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Type GetTypeFormAssembly(string assembly, Type type)
        {
            try
            {
                if (!File.Exists(assembly)) return null;
                Assembly assemblyTemp = Assembly.LoadFrom(assembly);
                Type[] types = assemblyTemp.GetTypes();
                foreach (Type item in types)
                {
                    Type[] typeInterfaces = item.GetInterfaces();
                    foreach (Type _interface in typeInterfaces)
                    {
                        if (_interface.AssemblyQualifiedName.Equals(type.AssemblyQualifiedName))
                        {
                            return item;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Type> GetInterfacesNames(string dllName,string interfaceType)
        {
            List<Type> retList = new List<Type>();
            if (File.Exists(dllName))
            {
                Assembly assembly = Assembly.LoadFile(dllName);
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type item in types)
                    {
                        if (item.GetInterface(interfaceType) != null)
                        {
                            retList.Add(item);
                        }
                    }
                }
            }
            return retList;
        }
    }
}
