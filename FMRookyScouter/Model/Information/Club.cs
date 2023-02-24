using Avalonia.Media.Imaging;
using FMRookyScouter.Interface;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Club : IXElementSerializable, IImagable
    {
        #region Properties
        public string Name { get; set; }
        public string Image => this.GetImagePath();
        #endregion

        #region Functions
        public override string ToString() => $"{Name} (img : {Image})";

        public XElement Save()
        {
            var element = new XElement(nameof(Club));

            element.Add(new XAttribute(nameof(Name), Name ?? ""));

            return element;
        }

        public void Load(XElement element)
        {
            if (element.Name != nameof(Club))
                return;

            if (element.TryGetAttributeValue(nameof(Name), out string name))
                Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Club other && Name == other.Name;
        }

        public override int GetHashCode()
        {
            var code = 123781314;

            code ^= Name.GetHashCode();

            return code;
        }
        #endregion
    }
}
