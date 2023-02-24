using FMRookyScouter.Service;
using Prism.Commands;
using ReactiveUI;
using System;
using System.Windows.Controls;

namespace FMRookyScouter.View
{
    public class FilterViewModel : ReactiveObject
    {
        public PlayerFilter Filter { get; }

        public DelegateCommand<TextChangedEventArgs> OnTextChangedCommand { get; }

        public FilterViewModel(PlayerFilter filter)
        {
            Filter = filter;

            OnTextChangedCommand = new DelegateCommand<TextChangedEventArgs>(OnTextChanged);
        }

        private void OnTextChanged(TextChangedEventArgs args)
        {
            if (!(args.Source is TextBox textBox))
                return;

            Filter.NamePattern = textBox.Text;
        }
    }
}
