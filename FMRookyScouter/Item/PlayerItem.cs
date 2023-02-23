using FMRookyScouter.Helper;
using FMRookyScouter.Model;
using ReactiveUI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FMRookyScouter.Item
{
    public class PlayerItem : ReactiveObject
    {
        private readonly Player _player;
        
        public string Name { get; }
        public string Positions { get;  }
        public int Potential { get; }
        public int Ability { get; }
        public string ClubName { get; }
        public string NationName { get; }
        public string PicturePath { get; }
        public string ClubLogoPath { get; }
        public string NationLogoPath { get; }

        public PlayerItem(Player player)
        {
            _player = player;

            Name = player.Common.Name;
            Potential = player.Potential;
            Ability = player.Ability;

            PicturePath = GetPicturePath(Name);

            Positions = GetPositions(player);
            ClubName = player.Club.Name;
            ClubLogoPath = GetClubLogoPath(player.Club?.Name);
            NationName = player.Nation.Name;
            NationLogoPath = GetNationLogoPath(player.Nation?.Name);
        }

        private static string GetPositions(Player player)
        {
            var positions = player.Common.Positions;
            if (positions == null || !positions.Any())
                return "-";

            return string.Join(" / ", positions);
        }

        private static string GetClubLogoPath(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            return $"/FMRookyScouter;component/Logo/{name.TrimEnglish()}.png";
        }

        private static string GetNationLogoPath(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            return $"/FMRookyScouter;component/Nation/{name.TrimEnglish()}.png";
        }

        private static string GetPicturePath(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            return $"/FMRookyScouter;component/Picture/{name.TrimEnglish()}.png";
        }
    }
}
