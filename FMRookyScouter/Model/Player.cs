using FMRookyScouter.Interface;
using FMRookyScouter.Model.Information;
using FMRookyScouter.Model.Spec;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace FMRookyScouter.Model
{
    public class Player : IXElementSerializable
    {
        #region Properties
        public int Ability { get; set; } = 0;
        public int Potential { get; set; } = 0;
        public Common Common { get; set; } = new Common();
        public Club Club { get; set; } = new Club();
        public Nation Nation { get; set; } = new Nation();
        public Mental Mental { get; set; } = new Mental();
        public Physical Physical { get; set; } = new Physical();
        public Technical Technical { get; set; } = new Technical();
        public Goalkeeping Goalkeeping { get; set; } = new Goalkeeping();
        #endregion

        #region Functions
        public void Load(XElement element)
        {
            if (element.Name != nameof(Player))
                return;

            if (element.TryGetAttributeIntValue(nameof(Ability), out int ability))
                Ability = ability;
            if (element.TryGetAttributeIntValue(nameof(Potential), out int potential))
                Potential = potential;

            var properties = typeof(Player).GetProperties();

            foreach (var property in properties)
            {
                var child = element.Element(property.Name);
                var value = property.GetValue(this);

                if (value is IXElementSerializable serializable)
                    serializable.Load(child);
            }
        }

        public XElement Save()
        {
            var element = new XElement(nameof(Player));

            element.Add(
                new XAttribute(nameof(Ability), Ability),
                new XAttribute(nameof(Potential), Potential));

            var properties = typeof(Player).GetProperties();

            foreach(var property in properties)
            {
                var value = property.GetValue(this);

                if(value is IXElementSerializable serializable)
                    element.Add(serializable.Save());
            }

            return element;
        }

        public override string ToString() => $"{Common.Name} ({Ability}, {Potential})";

        public string GetID() => $"{Common.Name} {Club.Name} {Nation.Name}";
        #endregion
    }
}
