using FMRookyScouter.Model.Attribute;
using FMRookyScouter.Model.Information;
using System.Xml.Linq;

namespace FMRookyScouter.Model
{
    public class Player
    {
        public int Ability { get; set; }
        public int Potential { get; set; }

        public Common Common { get; set; } = new Common();
        public Club Club { get; set; } = new Club();
        public Nation Nation { get; set; } = new Nation();
        public Mental Mental { get; set; } = new Mental();
        public Physical Physical { get; set; } = new Physical();
        public Technical Technical { get; set; } = new Technical();
        public Goalkeeping Goalkeeping { get; set; } = new Goalkeeping();

        public XElement Save()
        {
            var element = new XElement(nameof(Player));

            element.Add(
                new XAttribute(nameof(Ability), Ability),
                new XAttribute(nameof(Potential), Potential));

            element.Add(Common.Save());
            element.Add(Club.Save());
            element.Add(Nation.Save());
            element.Add(Mental.Save());
            element.Add(Physical.Save());
            element.Add(Technical.Save());
            element.Add(Goalkeeping.Save());

            return element;
        }
    }
}
