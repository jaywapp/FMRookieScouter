using FMRookyScouter.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;

namespace FMRookyScouter.View
{
    public class PlayersViewModel : ReactiveObject
    {
        public List<Player> Players { get; }

        private Player _selectedPlayer;

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }

        public PlayersViewModel(Sesson sesson)
        {
            Players = sesson.Players;

            this.WhenAnyValue(x => x.SelectedPlayer)
                .Subscribe(OnSelectedPlayerChanged);
        }

        private void OnSelectedPlayerChanged(Player obj)
        {
        }
    }
}
