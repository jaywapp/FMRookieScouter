using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Common
    {
        public string Image { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public double Length { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public ePosition[] Positions { get; set; }
        public eRole Role { get; set; }
        public eFoot Foot { get; set; }

        public XElement Save()
        {
            var element = new XElement(nameof(Club));

            element.Add(
                new XAttribute(nameof(Image), Image),
                new XAttribute(nameof(Name), Name),
                new XAttribute(nameof(Age), Age),
                new XAttribute(nameof(Length), Length),
                new XAttribute(nameof(Weight), Weight),
                new XAttribute(nameof(Role), Role),
                new XAttribute(nameof(Foot), Foot));

            element.Add(SavePositions());

            return element;
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
    }
}
