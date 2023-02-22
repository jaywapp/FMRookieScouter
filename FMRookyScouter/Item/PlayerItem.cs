using FMRookyScouter.Model;
using ReactiveUI;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace FMRookyScouter.Item
{
    public class PlayerItem : ReactiveObject
    {
        private readonly Player _player;
        
        public string Name { get; }
        public string Positions { get;  }
        public string ClubName { get; }
        public string NationName { get; }
        public BitmapImage Picture { get; }
        public BitmapImage ClubLogo { get; }
        public BitmapImage NationLogo { get; }

        public PlayerItem(Player player, Dictionary<string, BitmapImage> bitmaps)
        {
            _player = player;

            Name = player.Common.Name;
            Positions = player.Common?.Positions == null
                ? "-" : string.Join(" / ", player.Common?.Positions);

            ClubName = player.Club.Name;
            NationName = player.Nation.Name;

            if(!string.IsNullOrEmpty(Name) && bitmaps.ContainsKey(Name))
                Picture = bitmaps[Name];
            if (!string.IsNullOrEmpty(ClubName) && bitmaps.ContainsKey(ClubName))
                ClubLogo = bitmaps[ClubName];
            if (!string.IsNullOrEmpty(NationName) && bitmaps.ContainsKey(NationName))
                NationLogo = bitmaps[NationName];
        }
    }
}
