using FMRookyScouter.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Common : IXElementSerializable
    {
        #region Properties
        public string Image { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public double Length { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public ePosition[] Positions { get; set; }
        public eRole Role { get; set; }
        public eFoot Foot { get; set; }
        #endregion

        #region Functions
        public override string ToString() => $"Age : {Age} / L : {Length} / W : {Weight} / Foot : {Foot} / Image : {Image}";

        public XElement Save()
        {
            var element = new XElement(nameof(Common));

            element.Add(
                new XAttribute(nameof(Image), Image ?? ""),
                new XAttribute(nameof(Name), Name ?? ""),
                new XAttribute(nameof(Age), Age),
                new XAttribute(nameof(Length), Length),
                new XAttribute(nameof(Weight), Weight),
                new XAttribute(nameof(Role), Role),
                new XAttribute(nameof(Foot), Foot));

            element.Add(SavePositions());

            return element;
        }

        public void Load(XElement element)
        {
            if (element.Name != nameof(Common))
                return;

            if (element.TryGetAttributeValue(nameof(Image), out string image))
                Image = image;
            if (element.TryGetAttributeValue(nameof(Name), out string name))
                Name = name;
            if (element.TryGetAttributeIntValue(nameof(Age), out int age))
                Age = age;
            if (element.TryGetAttributeDoubleValue(nameof(Length), out double length))
                Length = length;
            if (element.TryGetAttributeDoubleValue(nameof(Weight), out double weight))
                Weight = weight;
            if (element.TryGetAttributeEnumValue(nameof(Foot), out eFoot foot))
                Foot = foot;
            if (element.TryGetAttributeEnumValue(nameof(Role), out eRole role))
                Role = role;

            var child = element.Element(nameof(Positions));
            if (child == null)
                return;

            LoadPositions(child);
        }

        private void LoadPositions(XElement element)
        {
            if (element.Name != nameof(Positions))
                return;

            var positions = new List<ePosition>();
            var children = element.Elements("Position");
            foreach(var child in children)
            {
                if (Enum.TryParse(child.Value, out ePosition position))
                    positions.Add(position);
            }
        }

        private XElement SavePositions()
        {
            var element = new XElement(nameof(Positions));

            foreach(var position in Positions)
            {
                var child = new XElement("Position");
                child.Value = position.ToString();

                element.Add(child);
            }

            return element;
        }
        #endregion
    }
}
