using FMRookyScouter.Interface;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Club : IXElementSerializable
    {
        #region Properties
        public string Image { get; set; }
        public string Name { get; set; }
        #endregion

        #region Functions
        public override string ToString() => $"{Name} (img : {Image})";

        public XElement Save()
        {
            var element = new XElement(nameof(Club));

            element.Add(
                new XAttribute(nameof(Image), Image ?? ""),
                new XAttribute(nameof(Name), Name ?? ""));

            return element;
        }


        public void Load(XElement element)
        {
            if (element.Name != nameof(Club))
                return;

            if (element.TryGetAttributeValue(nameof(Image), out string image))
                Image = image;
            if (element.TryGetAttributeValue(nameof(Name), out string name))
                Name = name;
        }
        #endregion
    }
}
