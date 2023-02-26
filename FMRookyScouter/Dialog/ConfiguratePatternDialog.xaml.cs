using FMRookyScouter.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FMRookyScouter.Dialog
{
    /// <summary>
    /// ConfiguratePatternDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConfiguratePatternDialog : Window, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties
        public IPlayerFilterPattern Pattern { get; private set; }
        #endregion

        #region Constructor
        public ConfiguratePatternDialog(IPlayerFilterPattern pattern = null)
        {
            Pattern = pattern;
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void Submit(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        #endregion
    }
}
