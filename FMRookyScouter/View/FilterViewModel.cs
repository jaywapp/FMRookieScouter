using FMRookyScouter.Dialog;
using FMRookyScouter.Interface;
using FMRookyScouter.Service.Filter;
using Prism.Commands;
using ReactiveUI;

namespace FMRookyScouter.View
{
    public class FilterViewModel : ReactiveObject
    {
        private IPlayerFilterPattern _selectedPattern;

        public PlayerFilter Filter { get; }

        public IPlayerFilterPattern SelectedPattern
        {
            get => _selectedPattern;
            set => this.RaiseAndSetIfChanged(ref _selectedPattern, value);
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand ModifyCommand { get; }
        public DelegateCommand ClearCommand { get; }

        public FilterViewModel(PlayerFilter filter)
        {
            Filter = filter;
            Filter.Patterns.ListChanged += (o, s) => Fetch();

            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete);
            ModifyCommand = new DelegateCommand(Modify);
            ClearCommand = new DelegateCommand(Clear);
        }

        private void Fetch()
        {
            this.RaisePropertyChanged(nameof(Filter.Patterns));
        }

        private void Add()
        {
            var dialog = new ConfiguratePatternDialog();
            if (dialog?.ShowDialog() != true)
                return;

            Filter.Patterns.Add(dialog.Pattern);
        }

        private void Delete()
        {
            if (SelectedPattern == null)
                return;

            Filter.Patterns.Remove(SelectedPattern);
        }

        private void Modify()
        {
            if (SelectedPattern == null)
                return;

            var dialog = new ConfiguratePatternDialog(SelectedPattern);
            if (dialog?.ShowDialog() != true)
                return;

            Fetch();
        }

        private void Clear()
        {
            Filter.Patterns.Clear();
        }
    }
}
