using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HR.Share.PublicShare
{
    public class Helper
    {
        /// <summary>
        /// 通过默认构造函数生成对象
        /// </summary>
        /// <param name="assembly">动态链接库</param>
        /// <param name="type">实现的接口类</param>
        /// <returns></returns>
        public static object GetIntanceFormAssembly(string assembly, Type type)
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

        /// <summary>
        /// 通过指定的构造函数生成对象
        /// </summary>
        /// <param name="assembly">动态链接库</param>
        /// <param name="type">实现的接口类</param>
        /// <param name="args">指定构造函数的参数</param>
        /// <returns></returns>
        public static object GetIntanceFormAssembly(string assembly, Type type, params object[] args)
        {
            Type objType = GetTypeFormAssembly(assembly, type);
            if (objType == null) return null;
            try
            {
                return Activator.CreateInstance(objType, args);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获得实现了某接口的类
        /// </summary>
        /// <param name="assembly">动态链接库</param>
        /// <param name="type">实现的接口类</param>
        /// <returns></returns>
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
        public static List<Type> GetInterfacesNames(string dllName, string interfaceType)
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
