using HR.Share.PublicShare.CustomClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Share.PublicShare.BaseClass
{
    public class CustomProperty/*: ICustomTypeDescriptor*/
    {
        private bool _save;
        private string _loadMsg = "欢迎进入";
        private int _count;
        private double _freq;
        private DateTime _dateTime;
        private string _filePath;

        [DisplayName("保存"), CategoryAttribute("配置"), DefaultValue(false), DescriptionAttribute("是否保存")]
        public bool Save { get => _save; set => _save = value; }
        [CategoryAttribute("配置"), DefaultValue("欢迎"), DescriptionAttribute("加载信息")]
        public string LoadMsg { get => _loadMsg; set => _loadMsg = value; }
        [CategoryAttribute("配置"), DefaultValue(1), DescriptionAttribute("数量")]
        public int Count { get => _count; set => _count = value; }
        [CategoryAttribute("配置"), DefaultValue(101.7), DescriptionAttribute("频率")]
        public double Freq { get => _freq; set => _freq = value; }
        [CategoryAttribute("配置"), DescriptionAttribute("日期")]
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
        [CategoryAttribute("配置"), DescriptionAttribute("选择文件"), EditorAttribute(typeof(PropertyGridOpenFile), typeof(System.Drawing.Design.UITypeEditor))]
        public string FilePath { get => _filePath; set => _filePath = value; }

        //public AttributeCollection GetAttributes()
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetClassName()
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetComponentName()
        //{
        //    throw new NotImplementedException();
        //}

        //public TypeConverter GetConverter()
        //{
        //    throw new NotImplementedException();
        //}

        //public EventDescriptor GetDefaultEvent()
        //{
        //    throw new NotImplementedException();
        //}

        //public PropertyDescriptor GetDefaultProperty()
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetEditor(Type editorBaseType)
        //{
        //    throw new NotImplementedException();
        //}

        //public EventDescriptorCollection GetEvents()
        //{
        //    throw new NotImplementedException();
        //}

        //public EventDescriptorCollection GetEvents(Attribute[] attributes)
        //{
        //    throw new NotImplementedException();
        //}

        //public PropertyDescriptorCollection GetProperties()
        //{
        //    throw new NotImplementedException();
        //}

        //public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        //{
        //    List<CustomPropertyDescriptor> tmpPDCLst = new List<CustomPropertyDescriptor>();
        //    //PropertyDescriptorCollection tmpPDC = TypeDescriptor.GetProperties(this, attributes);
        //    //IEnumerator tmpIe = tmpPDC.GetEnumerator();
        //    //CustomPropertyDescriptor tmpCPD;
        //    //PropertyDescriptor tmpPD;
        //    //while (tmpIe.MoveNext())
        //    //{
        //    //    tmpPD = tmpIe.Current as PropertyDescriptor;
        //    //    tmpCPD = new CustomPropertyDescriptor(mCurrentSelectObject, tmpPD);
        //    //    tmpCPD.SetDisplayName(mObjectAttribs[tmpPD.Name]);
        //    //    //此处用于处理属性分类的名称，可以在XML等设置文件中进行设置，在这段代码中只是简单的在分类后加了“中文”两个字 
        //    //    tmpCPD.SetCategory(tmpPD.Category + "中文");
        //    //    tmpPDCLst.Add(tmpCPD);
        //    //    //if (mObjectAttribs.ContainsKey(tmpPD.Name))
        //    //    //{
        //    //    //    tmpCPD = new CustomPropertyDescriptor(mCurrentSelectObject, tmpPD);
        //    //    //    tmpCPD.SetDisplayName(mObjectAttribs[tmpPD.Name]);
        //    //    //    //此处用于处理属性分类的名称，可以在XML等设置文件中进行设置，在这段代码中只是简单的在分类后加了“中文”两个字 
        //    //    //    tmpCPD.SetCategory(tmpPD.Category + "中文");
        //    //    //    tmpPDCLst.Add(tmpCPD);
        //    //    //}
        //    //}
        //    return new PropertyDescriptorCollection(tmpPDCLst.ToArray());
        //}

        //public object GetPropertyOwner(PropertyDescriptor pd)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
