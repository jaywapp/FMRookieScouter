using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Mental
    {
        public int Aggression { get; set; } = 0;
        public int Anticipation { get; set; } = 0;
        public int Bravery { get; set; } = 0;
        public int Composure { get; set; } = 0;
        public int Concentration { get; set; } = 0;
        public int Decisions { get; set; } = 0;
        public int Determination { get; set; } = 0;
        public int Flair { get; set; } = 0;
        public int Leadership { get; set; } = 0;
        public int OffTheBall { get; set; } = 0;
        public int Positioning { get; set; } = 0;
        public int Teamwork { get; set; } = 0;
        public int Vision { get; set; } = 0;
        public int WorkRate { get; set; } = 0;

        public XElement Save()
        {
            var element = new XElement(nameof(Mental));

            var properties = typeof(Mental).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                if (value == null)
                    continue;

                element.Add(new XAttribute(property.Name, value));
            }

            return element;
        }
    }
}
