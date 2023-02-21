using System.Xml.Linq;

namespace FMRookyScouter.Model.Information
{
    public class Club
    {
        #region Properties
        public string Image { get; set; }
        public string Name { get; set; }
        #endregion

        #region Functions
        public XElement Save()
        {
            var element = new XElement(nameof(Club));

            element.Add(
                new XAttribute(nameof(Image), Image),
                new XAttribute(nameof(Name), Name));

            return element;
        }
        #endregion
    }
}
