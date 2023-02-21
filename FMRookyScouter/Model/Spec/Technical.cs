using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Technical
    {
        public int Corners { get; set; } = 0;
        public int Crossing { get; set; } = 0;
        public int Dribbling { get; set; } = 0;
        public int Finishing { get; set; } = 0;
        public int FirstTouch { get; set; } = 0;
        public int FreeKickTaking { get; set; } = 0;
        public int Heading { get; set; } = 0;
        public int LongShots { get; set; } = 0;
        public int LongThrows { get; set; } = 0;
        public int Marking { get; set; } = 0;
        public int Passing { get; set; } = 0;
        public int PenaltyTaking { get; set; } = 0;
        public int Tackling { get; set; } = 0;
        public int Technique { get; set; } = 0;

        public XElement Save()
        {
            var element = new XElement(nameof(Technical));

            var properties = typeof(Technical).GetProperties();

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
