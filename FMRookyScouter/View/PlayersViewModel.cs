using FMRookyScouter.Dialog;
using FMRookyScouter.Interface;
using FMRookyScouter.Model;
using Prism.Commands;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;

namespace FMRookyScouter.View
{
    public class PlayersViewModel : ReactiveObject
    {
        #region Internal Field
        private Player _selectedPlayer;
        private List<Player> _displayPlayers;
        private IPlayerFilter _filter;
        #endregion

        #region Properties
        public List<Player> Players { get; }
        public List<Player> DisplayPlayers
        {
            get => _displayPlayers;
            set => this.RaiseAndSetIfChanged(ref _displayPlayers, value);
        }

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
        }

        public IPlayerFilter Filter
        {
            get => _filter;
            set => this.RaiseAndSetIfChanged(ref _filter, value);
        }
        #endregion

        #region Commands
        public DelegateCommand<MouseButtonEventArgs> DoubleClickCommand { get; }
        #endregion

        #region Constructor
        public PlayersViewModel(Sesson sesson)
        {
            Players = sesson.Players;

            this.WhenAnyValue(x => x.Filter)
                .Where(filter => filter != null)
                .Subscribe(filter => filter.ConditionChanged += OnConditionChanged);

            this.WhenAnyValue(x => x.Filter)
                .Select(filter => Filtering(filter, Players))
                .BindTo(this, x => x.DisplayPlayers);

            DoubleClickCommand = new DelegateCommand<MouseButtonEventArgs>(DoubleClick);
        }

        #endregion


        private void OnConditionChanged(object sender, EventArgs e)
        {
            if (!(sender is IPlayerFilter filter))
                return;

            DisplayPlayers = filter.Filtering(Players).ToList();
        }

        private void DoubleClick(MouseButtonEventArgs e)
        {
            if (SelectedPlayer == null)
                return;

            var dialog = new PlayerAnalysisDialog(SelectedPlayer);
            if (dialog?.ShowDialog() != true)
                return;
        }

        private static List<Player> Filtering(IPlayerFilter filter, IEnumerable<Player> sources)
        {
            return filter?.Filtering(sources)?.ToList() ?? sources.ToList();
        }
    }
}
