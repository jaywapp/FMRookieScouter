using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Physical
    {
        public int Acceleration { get; set; } = 0;
        public int Agility { get; set; } = 0;
        public int Balance { get; set; } = 0;
        public int JumpingReach { get; set; } = 0;
        public int NaturalFitness { get; set; } = 0;
        public int Pace { get; set; } = 0;
        public int Stamina { get; set; } = 0;
        public int Strength { get; set; } = 0;

        public XElement Save()
        {
            var element = new XElement(nameof(Physical));

            var properties = typeof(Physical).GetProperties();

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
