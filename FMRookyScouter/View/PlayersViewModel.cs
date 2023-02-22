using FMRookyScouter.Item;
using FMRookyScouter.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace FMRookyScouter.View
{
    public class PlayersViewModel : ReactiveObject
    {
        public List<PlayerItem> Players { get; }
        public Dictionary<string, BitmapImage> Bitmaps { get; }

        private Player _selectedPlayer;

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }

        public PlayersViewModel(Sesson sesson, Dictionary<string, BitmapImage> bitmaps)
        {
            Players = sesson.Players.Select(p=> new PlayerItem(p, bitmaps)).ToList();
            Bitmaps = bitmaps;

            this.WhenAnyValue(x => x.SelectedPlayer)
                .Subscribe(OnSelectedPlayerChanged);
        }

        private void OnSelectedPlayerChanged(Player obj)
        {
        }
    }
}
