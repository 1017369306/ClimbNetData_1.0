namespace HR.Share.PublicShare.CustomClass
{
    public class ProPertyGridHelper/*: ICustomTypeDescriptor*/
    {

        //public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        //{
        //    List<CustomPropertyDescriptor> tmpPDCLst = new List<CustomPropertyDescriptor>();
        //    PropertyDescriptorCollection tmpPDC = TypeDescriptor.GetProperties(mCurrentSelectObject, attributes);
        //    IEnumerator tmpIe = tmpPDC.GetEnumerator();
        //    CustomPropertyDescriptor tmpCPD;
        //    PropertyDescriptor tmpPD;
        //    while (tmpIe.MoveNext())
        //    {
        //        tmpPD = tmpIe.Current as PropertyDescriptor;
        //        if (mObjectAttribs.ContainsKey(tmpPD.Name))
        //        {
        //            tmpCPD = new CustomPropertyDescriptor(mCurrentSelectObject, tmpPD);
        //            tmpCPD.SetDisplayName(mObjectAttribs[tmpPD.Name]);
        //            //此处用于处理属性分类的名称，可以在XML等设置文件中进行设置，在这段代码中只是简单的在分类后加了“中文”两个字 
        //            tmpCPD.SetCategory(tmpPD.Category + "中文");
        //            tmpPDCLst.Add(tmpCPD);
        //        }
        //    }
        //    return new PropertyDescriptorCollection(tmpPDCLst.ToArray());
        //}
    }
}
