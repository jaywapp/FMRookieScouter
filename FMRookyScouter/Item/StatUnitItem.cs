using ReactiveUI;
using System;
using System.Windows.Media;

namespace FMRookyScouter.Item
{
    public class StatUnitItem 
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Color Color => GetColor();
        
        private Color GetColor()
        {
            return Colors.Yellow;
            var color = Colors.Green;

            var alpha = 0;
            var interval = byte.MaxValue / 20;
            alpha += (interval) * Value;

            return Color.FromArgb((byte)alpha, color.R, color.G, color.B);
        }
    }
}
