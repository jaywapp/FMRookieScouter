using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Goalkeeping
    {
        public int AerialReach { get; set; } = 0;
        public int CommandOfArea { get; set; } = 0;
        public int Communication { get; set; } = 0;
        public int Eccentricity { get; set; } = 0;
        public int FirstTouch { get; set; } = 0;
        public int Handling { get; set; } = 0;
        public int Kicking { get; set; } = 0;
        public int OneOnOnes { get; set; } = 0;
        public int Passing { get; set; } = 0;
        public int Punching { get; set; } = 0;
        public int Reflexes { get; set; } = 0;
        public int RushingOut { get; set; } = 0;
        public int Throwing { get; set; } = 0;

        public XElement Save()
        {
            var element = new XElement(nameof(Goalkeeping));

            var properties = typeof(Goalkeeping).GetProperties();

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
