using System;
using System.ComponentModel;
using System.Reflection;

namespace HR.Share.PublicShare.CustomClass
{
    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        PropertyInfo info;
        public CustomPropertyDescriptor(PropertyInfo propertyInfo, Attribute[] attrs) :
        base(propertyInfo.Name, attrs)
        {
            this.info = propertyInfo;
        }

        private string mCategory;
        public override string Category
        {
            get { return mCategory; }
        }
        private string mDisplayName;
        public override string DisplayName
        {
            get { return mDisplayName; }
        }

        public override Type ComponentType => throw new NotImplementedException();

        public override bool IsReadOnly => throw new NotImplementedException();

        public override Type PropertyType => throw new NotImplementedException();

        public void SetDisplayName(string pDispalyName)
        {
            mDisplayName = pDispalyName;
        }
        public void SetCategory(string pCategory)
        {
            mCategory = pCategory;
        }

        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }
    }
}
