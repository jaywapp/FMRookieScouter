using FMRookyScouter.Interface;
using System.Xml.Linq;

namespace FMRookyScouter.Model.Spec
{
    public class Physical : IXElementSerializable
    {
        #region Properties
        public int Acceleration { get; set; } = 0;
        public int Agility { get; set; } = 0;
        public int Balance { get; set; } = 0;
        public int JumpingReach { get; set; } = 0;
        public int NaturalFitness { get; set; } = 0;
        public int Pace { get; set; } = 0;
        public int Stamina { get; set; } = 0;
        public int Strength { get; set; } = 0;
        #endregion

        #region Functions
        public void Load(XElement element) => this.LoadSpec(element);
        public XElement Save() => this.SaveSpec();
        #endregion
    }
}
