using FMRookyScouter.Interface;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Goalkeeping : IXElementSerializable
    {
        #region Properties
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
        #endregion

        #region Functions
        public void Load(XElement element) => this.LoadSpec(element);
        public XElement Save() => this.SaveSpec();
        #endregion
    }
}
