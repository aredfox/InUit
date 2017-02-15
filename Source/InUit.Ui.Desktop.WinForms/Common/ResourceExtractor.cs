using System;
using System.Drawing;
using System.Reflection;

namespace InUit.Ui.Desktop.WinForms.Common
{
    public class ResourceExtractor
    {
        private static string _imageResources = "InUit.Resources.Images";        

        public static Icon GetIcon(string name) {
            Icon icon = null;            

            using (var stream = Assembly.Load(_imageResources).GetManifestResourceStream(String.Concat(_imageResources, ".Images.", name))) {
                icon = new Icon(stream);
            }

            return icon;
        }
    }
}
