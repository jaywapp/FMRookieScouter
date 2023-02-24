using FMRookyScouter.Model;
using ReactiveUI;
using System.Collections.Generic;

namespace FMRookyScouter.View
{
    public class PlayersViewModel : ReactiveObject
    {
        #region Internal Field
        private Player _selectedPlayer;
        #endregion

        #region Properties
        public List<Player> Players { get; }

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }
        #endregion

        #region Constructor
        public PlayersViewModel(Sesson sesson)
        {
            Players = sesson.Players;
        }
        #endregion
    }
}
