using FMRookyScouter.Helper;
using FMRookyScouter.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Common : IXElementSerializable
    {
        #region Properties
        public string Image => GetImagePath(Name);
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public double Length { get; set; } = 0; 
        public double Weight { get; set; } = 0;
        public ePosition[] Positions { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public eFoot Foot { get; set; }
        #endregion

        #region Functions
        public string GetPositions()
        {
            return string.Join(" / ", Positions);
        }

        private static string GetImagePath(string name)
        {
            var prefix = "/FMRookyScouter;component/Image/Picture";
            var ext = "png";

            return $"{prefix}/{name.TrimEnglish()}.{ext}";
        }

        public override string ToString() => $"Age : {Age} / L : {Length} / W : {Weight} / Foot : {Foot} / Image : {Image}";

        public XElement Save()
        {
            var element = new XElement(nameof(Common));

            element.Add(
                new XAttribute(nameof(Name), Name ?? ""),
                new XAttribute(nameof(Age), Age),
                new XAttribute(nameof(Length), Length),
                new XAttribute(nameof(Weight), Weight),
                new XAttribute(nameof(Foot), Foot));

            element.Add(SavePositions());
            element.Add(SaveRoles());

            return element;
        }

        public void Load(XElement element)
        {
            if (element.Name != nameof(Common))
                return;

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

            LoadPositions(element.Element(nameof(Positions)));
            LoadRoles(element.Element(nameof(Roles)));
        }

        private void LoadPositions(XElement element)
        {
            if (element == null)
                return;
            if (element.Name != nameof(Positions))
                return;

            var positions = new List<ePosition>();
            var children = element.Elements("Position");
            foreach (var child in children)
            {
                if (Enum.TryParse(child.Value, out ePosition position))
                    positions.Add(position);
            }

            Positions = positions.ToArray();
        }

        private void LoadRoles(XElement element)
        {
            if (element == null)
                return;
            if (element.Name != nameof(Roles))
                return;

            var roles = new List<Role>();

            var children = element.Elements(nameof(Role));
            foreach (var child in children)
            {
                var role = new Role();

                role.Load(child);
                roles.Add(role);
            }

            Roles = roles;
        }

        private XElement SavePositions()
        {
            var element = new XElement(nameof(Positions));

            foreach (var position in Positions)
            {
                var child = new XElement("Position");
                child.Value = position.ToString();

                element.Add(child);
            }

            return element;
        }

        private XElement SaveRoles()
        {
            var element = new XElement(nameof(Roles));

            foreach (var role in Roles)
                element.Add(role.Save());

            return element;
        }
        #endregion
    }
}
