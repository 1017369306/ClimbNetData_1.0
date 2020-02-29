using HR.Share.PublicShare.BaseClass.AbstractClass;
using Log4Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;

namespace HR.Share.PublicShare
{
    public class MainBaseMethod
    {
        #region 常量

        /// <summary>
        /// 京东评论js url
        /// </summary>
        //[CreateMsgAttribute(createTime: "2020-2-10", createBy: "张洋")]
        public const string version = "Z-1.0";
        /// <summary>
        /// 京东评论js返回数据的header
        /// </summary>
        //[CreateMsgAttribute(createTime: "2020-2-11", createBy: "张洋")]
        public const string CommentHeader = "fetchJSON_comment98vv2020";
        public const string JdGoodsCommentJsUrl = "https://club.jd.com/comment/productPageComments.action?callback=fetchJSON_comment98vv2901&productId=100004508929&score=0&sortType=5&page=0&pageSize=10&isShadowSku=0&fold=1";
        #endregion

        #region 枚举
        public enum JdCommentJsType
        {
            club,
            sclub
        }
        #endregion


        public static string GetJdGoodsCommentJsUrl(object type, string productId, int pageIndex,int pageSize)
        {
            try
            {
                string JdGoodsCommentJsUrl = "https://" + type.ToString() + ".jd.com/comment/productPageComments.action?callback="+ CommentHeader + "&productId=" + productId + "&score=0&sortType=5&page=" + pageIndex + "&pageSize=" + pageSize + "&isShadowSku=0&rid=0&fold=1";//rid为全查，没有为只查前1000条
                return JdGoodsCommentJsUrl;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// 获得枚举的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            string temp = JdGoodsCommentJsUrl;
            temp = "";
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);//反射获取其属性的描述，这里的属性是指当前字段上的描述属性等
            if (objs == null || objs.Length == 0)
            {
                return value;
            }
            DescriptionAttribute description = (DescriptionAttribute)objs[0];
            return description.Description;
        }

        /// <summary>
        /// 获得枚举的指定属性
        /// </summary>
        /// <typeparam name="T">要获取的属性</typeparam>
        /// <param name="enumValue">枚举</param>
        /// <returns></returns>
        public static T GetEnumDescription<T>(Enum enumValue)
        {
            try
            {
                string value = enumValue.ToString();
                FieldInfo field = enumValue.GetType().GetField(value);
                object[] objs = field.GetCustomAttributes(typeof(T), false);//反射获取其属性的描述，这里的属性是指当前字段上的描述属性等
                if (objs == null || objs.Length == 0)
                {
                    return default(T);
                }
                T t = (T)objs[0];
                return t;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获得属性的指定特性
        /// </summary>
        /// <typeparam name="T">指定特性</typeparam>
        /// <param name="obj">属性</param>
        /// <returns></returns>
        public static T GetEntityDescription<T>(PropertyInfo obj)
        {
            try
            {
                object[] objs = obj.GetCustomAttributes(typeof(T), false);
                if (objs == null || objs.Length == 0)
                {
                    return default(T);
                }
                T t = (T)objs[0];
                return t;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获得属性名的指定特性
        /// </summary>
        /// <typeparam name="T">特性</typeparam>
        /// <typeparam name="E">实体类</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public static T GetEntityDescription<T, E>(string propertyName)
        {
            try
            {
                PropertyInfo propertyInfo = Activator.CreateInstance<E>().GetType().GetProperty(propertyName);
                object[] objs = propertyInfo.GetCustomAttributes(typeof(T), false);
                if (objs == null || objs.Length == 0)
                {
                    return default(T);
                }
                T t = (T)objs[0];
                return t;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// DataTable利用泛型填充实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="entityDt">DataTable</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<T> DataTableToEntityList<T>(DataTable entityDt)
        {
            try
            {
                List<T> list = new List<T>();
                T t = default(T);
                PropertyInfo[] propertyInfos = null;
                string tempName = string.Empty;
                foreach (DataRow dr in entityDt.Rows)
                {
                    t = Activator.CreateInstance<T>();
                    propertyInfos = t.GetType().GetProperties();
                    foreach (PropertyInfo pro in propertyInfos)
                    {
                        tempName = pro.Name;
                        if (entityDt.Columns.Contains(tempName))
                        {
                            object value = dr[tempName];
                            if (value != null && value.ToString() != "")
                            {
                                pro.SetValue(t, value, null);
                            }
                        }
                    }
                    list.Add(t);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 打印出实体类信息（每个属性换行）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string WriteLineList<T>(T entity,int flag)
        {
            try
            {
                if (entity == null) return null;
                //T t = default(T);
                string interval = "          ";
                PropertyInfo[] propertyInfos = null;
                //t = Activator.CreateInstance<T>();
                propertyInfos = entity.GetType().GetProperties();
                StringBuilder str = new StringBuilder();
                if (flag != 0)
                {
                    StringBuilder header = new StringBuilder();
                    foreach (PropertyInfo pro in propertyInfos)
                    {
                        object value = pro.Name;
                        if (value != null)
                        {
                            header.Append(value.ToString() + interval);
                        }
                    }
                    str.AppendLine(header.ToString());
                }
                foreach (PropertyInfo pro in propertyInfos)
                {
                    object value = pro.GetValue(entity);
                    if (flag == 0)
                    {
                        str.AppendLine(pro.Name + ":" + (value != null ? value.ToString() : ""));
                    }
                    else
                    {
                        str.Append((value != null ? (value.ToString()+ interval) : interval));
                    }
                }
                return str.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return null;
            }
        }

        public static List<string> WriteLineList<T>(List<T> list)
        {
            try
            {
                List<string> retList = new List<string>();
                if (list == null) return retList;
                T t = default(T);
                PropertyInfo[] propertyInfos = null;
                t = Activator.CreateInstance<T>();
                propertyInfos = t.GetType().GetProperties();
                foreach (T item in list)
                {
                    StringBuilder str = new StringBuilder();
                    foreach (PropertyInfo pro in propertyInfos)
                    {
                        object value = pro.GetValue(item);
                        str.AppendLine(pro.Name + ":" + (value != null ? value.ToString() : ""));
                    }
                    //Console.WriteLine(str.ToString());
                    retList.Add(str.ToString());
                }
                return retList;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return new List<string>();
            }
        }

        /// <summary>
        /// 创建List副本
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">List</param>
        /// <returns></returns>
        public static List<T> CloneList<T>(object list)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, list);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as List<T>;
            }
        }


        /// <summary>
        /// 创建List副本
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">List</param>
        /// <returns></returns>
        public static BindingList<T> CloneBindingList<T>(object list)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, list);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as BindingList<T>;
            }
        }


        /// 将字节数组转换成结构
        /// </summary>
        /// <param name="bytes">表示一个结构的字节数组</param>
        /// <param name="type">结构的类型</param>
        /// <returns>返回该类型的结构</returns>
        public static object BytesToStuct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }
        /// <summary>
        /// 将字节数组转换成结构
        /// </summary>
        /// <param name="bytes">表示一个结构的字节数组</param>
        /// <param name="offset">该结构在字节数组中的偏移量</param>
        /// <param name="type">结构的类型</param>
        /// <returns>返回该类型的结构</returns>
        public static object BytesToStuct(byte[] bytes, int offset, Type type)
        {
            try
            {
                int size = Marshal.SizeOf(type);
                if (size > bytes.Length)
                {
                    return null;
                }
                IntPtr structPtr = Marshal.AllocHGlobal(size);
                Marshal.Copy(bytes, offset, structPtr, size);
                object obj = Marshal.PtrToStructure(structPtr, type);
                Marshal.FreeHGlobal(structPtr);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将结构转换成字节数组
        /// </summary>
        /// <param name="structObj">一个结构</param>
        /// <returns>返回表征该结构的字节数组</returns>
        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structObj, structPtr, false);
            Marshal.Copy(structPtr, bytes, 0, size);
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }

        private delegate void InvokeChangeBtnStatus(System.Windows.Forms.Control control, bool status);
        /// <summary>
        /// 跨线程改变控件的状态
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="status"></param>
        public static void ChangeBtnStatus(System.Windows.Forms.Control control, bool status)
        {
            try
            {
                if (control.InvokeRequired)//当是不同的线程在访问时为true，所以这里是true
                {
                    InvokeChangeBtnStatus invoke = new InvokeChangeBtnStatus(ChangeBtnStatus);
                    control.Invoke(invoke, new object[] { control, status });
                }
                else
                {
                    lock (control)
                    {
                        control.Enabled = status;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private delegate void InvokeChangeBtnValue(System.Windows.Forms.Control control, string value);
        /// <summary>
        /// 跨线程改变控件的text
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="value"></param>
        public static void ChangeBtnValue(System.Windows.Forms.Control control, string value)
        {
            try
            {
                //List<int> list = null;
                //list.Clear();
                if (control.InvokeRequired)//当是不同的线程在访问时为true，所以这里是true
                {
                    InvokeChangeBtnValue invoke = new InvokeChangeBtnValue(ChangeBtnValue);
                    control.Invoke(invoke, new object[] { control, value });
                }
                else
                {
                    lock (control)
                    {
                        if(control is System.Windows.Forms.TextBox)
                        {
                            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)control;
                            txt.AppendText(value + "\r\n");
                            return;
                        }
                        control.Text = value;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private delegate void InvokeCallbackClear(System.Windows.Forms.TextBox textBox);
        /// <summary>
        /// 清除textbox文本内容
        /// </summary>
        /// <param name="textBox"></param>
        public static void ClearTextBox(System.Windows.Forms.TextBox textBox)
        {
            try
            {
                if (textBox.InvokeRequired)//当是不同的线程在访问时为true，所以这里是true
                {
                    InvokeCallbackClear invokeCallbackClear = new InvokeCallbackClear(ClearTextBox);
                    textBox.Invoke(invokeCallbackClear, new object[] { textBox });
                }
                else
                {
                    lock (textBox)
                    {
                        if (textBox.TextLength > 25000)
                            textBox.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        #region 跟UserControlBaseClass有关的方法
        /// <summary>
        /// 根据UserControlBaseClass子类获取LayoutDocument面板，用于添加到页面上
        /// </summary>
        /// <param name="userControl"></param>
        /// <returns></returns>
        public static LayoutDocument GetLayoutDocument(UserControlBaseClass userControl)
        {
            try
            {
                LayoutDocument ld = new LayoutDocument();
                ld.Title = userControl.Title;
                ld.Content = userControl.Control;
                ld.IsActive = true;
                return ld;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
