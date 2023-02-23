using FMRookyScouter.Item;
using FMRookyScouter.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMRookyScouter.View
{
    public class PlayersViewModel : ReactiveObject
    {
        #region Internal Field
        private PlayerItem _selectedPlayer;
        #endregion

        #region Properties
        public List<PlayerItem> Players { get; }

        public PlayerItem SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }
        #endregion

        #region Constructor
        public PlayersViewModel(Sesson sesson)
        {
            Players = sesson.Players.Select(p=> new PlayerItem(p)).ToList();
        }
        #endregion
    }
}
