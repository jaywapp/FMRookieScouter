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
        public List<PlayerItem> Players { get; }

        private Player _selectedPlayer;

        public int MinWidth { get; } = 200;
        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }

        public PlayersViewModel(Sesson sesson)
        {
            Players = sesson.Players.Select(p=> new PlayerItem(p)).ToList();

            this.WhenAnyValue(x => x.SelectedPlayer)
                .Subscribe(OnSelectedPlayerChanged);
        }

        private void OnSelectedPlayerChanged(Player obj)
        {
        }
    }
}
