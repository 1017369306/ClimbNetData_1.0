using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostinetSample
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    //propertyGrid1.SelectedObject=new LostinetSample.PropertyNameView(new LostinetSample.Class1());
    public class Class1
    {
        [Category("下一步")]
        [Description("你要去的地方")]
        [PropertyName("哪里？")]
        public string Where
        {
            get
            {
                return "any";
            }
        }
    }

    public class PropertyNameAttribute : Attribute
    {
        string n;
        public PropertyNameAttribute(string name)
        {
            n = name;
        }
        public string Name
        {
            get
            {
                return n;
            }
        }
    }

    public class PropertyDescriptorView : PropertyDescriptorWrapperBase
    {
        public PropertyDescriptorView(PropertyDescriptor basedesc) : base(basedesc, GetPropertyName(basedesc), (Attribute[])new ArrayList(basedesc.Attributes).ToArray(typeof(Attribute)))
        {
        }
        static public string GetPropertyName(PropertyDescriptor pd)
        {
            foreach (Attribute attr in pd.Attributes)
            {
                if (attr is PropertyNameAttribute)
                {
                    return ((PropertyNameAttribute)attr).Name;
                }
            }
            return pd.Name;
        }
    }

    #region PropertyDescriptorWrapperBase
    public class PropertyDescriptorWrapperBase : PropertyDescriptor
    {
        PropertyDescriptor pd;
        public PropertyDescriptorWrapperBase(PropertyDescriptor basedesc, string name, Attribute[] attributes) : base(name, attributes)
        {
            pd = basedesc;
        }
        public PropertyDescriptorWrapperBase(PropertyDescriptor basedesc) : base(basedesc.Name, (Attribute[])new ArrayList(basedesc.Attributes).ToArray(typeof(Attribute)))
        {
            pd = basedesc;
        }

        protected PropertyDescriptor BaseDescriptor
        {
            get
            {
                return pd;
            }
        }

        #region Wrapped
        public override bool CanResetValue(object component)
        {
            return pd.CanResetValue(component);
        }
        public override Type ComponentType
        {
            get
            {
                return pd.ComponentType;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return pd.IsReadOnly;
            }
        }
        public override bool IsBrowsable
        {
            get
            {
                return pd.IsBrowsable;
            }
        }
        public override Type PropertyType
        {
            get
            {
                return pd.PropertyType;
            }
        }
        public override void ResetValue(object component)
        {
            pd.ResetValue(component);
        }
        public override object GetValue(object component)
        {
            return pd.GetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            pd.SetValue(component, value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return pd.ShouldSerializeValue(component);
        }
        #endregion
    }

    #endregion

    public class PropertyNameView : ICustomTypeDescriptor
    {
        object obj;
        public PropertyNameView(object target)
        {
            if (target == null) throw (new ArgumentNullException("target"));
            if (target is PropertyNameView) throw (new ArgumentException("将导致循环调用~~"));
            obj = target;
        }
        protected virtual PropertyDescriptorCollection WrapCollection(PropertyDescriptorCollection coll)
        {
            PropertyDescriptorCollection newcoll = new PropertyDescriptorCollection(null);
            foreach (PropertyDescriptor pd in coll)
            {
                newcoll.Add(new PropertyDescriptorView(pd));
            }
            return newcoll;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return WrapCollection(TypeDescriptor.GetProperties(obj, attributes));
        }

        PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties()
        {
            return WrapCollection(TypeDescriptor.GetProperties(obj));
        }

        #region Wrapped
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(obj);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(obj, attributes);
        }

        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(obj);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(obj);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return obj;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(obj);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(obj, editorBaseType);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(obj);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(obj);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(obj);
        }
        #endregion
    }
}
