using FMRookyScouter.Access;
using FMRookyScouter.Interface;
using FMRookyScouter.Model;
using FMRookyScouter.Service;
using FMRookyScouter.View;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FMRookyScouter
{
    public class MainWindowViewModel : ReactiveObject
    {
        #region Internal Field
        private PlayerFilter _filter;
        #endregion

        #region Properties
        public PlayerFilter Filter
        {
            get => _filter;
            set => this.RaiseAndSetIfChanged(ref _filter, value);
        }
        #endregion

        public DBAccess Access { get; }
        public FilterViewModel FilterViewModel { get; }
        public List<TabItem> Tabs { get; }


        public MainWindowViewModel()
        {
            Access = new DBAccess();
            Filter = new PlayerFilter();

            Tabs = Access.Sessons.Values.Select(s=> CreateTabItem(s, Filter)).ToList();
            FilterViewModel = new FilterViewModel(Filter);

            this.WhenAnyValue(x => x.Filter)
                .Subscribe(filter =>
                {
                    foreach (var tab in Tabs)
                    {
                        if (TryGetViewModel(tab, out PlayersViewModel vm))
                            vm.Filter = filter;
                    }
                });
        }

        private static TabItem CreateTabItem(Sesson sesson, PlayerFilter filter)
        {
            var playersViewModel = new PlayersViewModel(sesson);
            playersViewModel.Filter = filter;

            return new TabItem()
            {
                Header = sesson.Year,
                Content = new PlayersView() { DataContext = playersViewModel, },
            };
        }

        private static bool TryGetViewModel(TabItem tabItem, out PlayersViewModel vm)
        {
            vm = null;

            if (!(tabItem.Content is PlayersView view))
                return false;

            if (!(view.DataContext is PlayersViewModel viewModel))
                return false;

            vm = viewModel;
            return true;
        }
    }
}
