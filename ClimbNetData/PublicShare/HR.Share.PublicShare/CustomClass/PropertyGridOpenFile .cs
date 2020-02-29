using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace HR.Share.PublicShare.CustomClass
{
    public class PropertyGridOpenFile : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.
        IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc =
            (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                // 可以打开任何特定的对话框  
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.AddExtension = false;
                if (dialog.ShowDialog().Equals(DialogResult.OK))
                {
                    return dialog.FileName;
                }
            }
            return value;
        }
    }
}
