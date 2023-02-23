using FMRookyScouter.Helper;
using FMRookyScouter.Model;
using ReactiveUI;

namespace FMRookyScouter.Item
{
    public class PlayerItem : ReactiveObject
    {
        private readonly Player _player;
        
        public string Name { get; }
        public string Positions { get;  }
        public string ClubName { get; }
        public string NationName { get; }
        public string PicturePath { get; }
        public string ClubLogoPath { get; }
        public string NationLogoPath { get; }

        public PlayerItem(Player player)
        {
            _player = player;

            Name = player.Common.Name;
            PicturePath = GetPicturePath(Name);

            Positions = player.Common?.Positions == null
                ? "-" : string.Join(" / ", player.Common?.Positions);
            ClubName = player.Club.Name;
            ClubLogoPath = GetLogoPath(player.Club?.Name);
            NationName = player.Nation.Name;
            NationLogoPath = GetLogoPath(player.Nation?.Name);
        }

        private static string GetLogoPath(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            return $"/FMRookyScouter;component/Logo/{name.TrimEnglish()}.png";
        }

        private static string GetPicturePath(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            return $"/FMRookyScouter;component/Picture/{name.TrimEnglish()}.png";
        }
    }
}
