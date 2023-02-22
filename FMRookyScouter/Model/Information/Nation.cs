using Avalonia.Media.Imaging;
using FMRookyScouter.Interface;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Nation : IXElementSerializable, IHasImage
    {
        #region Properties
        public string Image { get; set; }
        public string Name { get; set; }
        #endregion

        #region Functions
        public override string ToString() => $"{Name} (img : {Image})";

        public XElement Save()
        {
            var element = new XElement(nameof(Nation));

            element.Add(
                new XAttribute(nameof(Image), Image ?? ""),
                new XAttribute(nameof(Name), Name ?? ""));

            return element;
        }

        public void Load(XElement element)
        {
            if (element.Name != nameof(Nation))
                return;

            if (element.TryGetAttributeValue(nameof(Image), out string image))
                Image = image;
            if (element.TryGetAttributeValue(nameof(Name), out string name))
                Name = name;
        }


        public override bool Equals(object obj)
        {
            return obj is Nation other
                && Name == other.Name
                && Image == other.Image;
        }

        public override int GetHashCode()
        {
            var code = 98609511;

            code ^= Name.GetHashCode();
            code ^= Image.GetHashCode();

            return code;
        }
        #endregion
    }
}
