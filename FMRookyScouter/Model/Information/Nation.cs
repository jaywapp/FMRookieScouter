using FMRookyScouter.Interface;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Nation : IXElementSerializable, IImagable
    {
        #region Properties
        public string Name { get; set; }
        public string Image => this.GetImagePath();
        #endregion

        #region Functions
        public override string ToString() => $"{Name} (img : {Image})";

        public XElement Save()
        {
            var element = new XElement(nameof(Nation));

            element.Add(new XAttribute(nameof(Name), Name ?? ""));

            return element;
        }

        public void Load(XElement element)
        {
            if (element.Name != nameof(Nation))
                return;

            if (element.TryGetAttributeValue(nameof(Name), out string name))
                Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Nation other && Name == other.Name;
        }

        public override int GetHashCode()
        {
            var code = 98609511;

            code ^= Image.GetHashCode();

            return code;
        }
        #endregion
    }
}
