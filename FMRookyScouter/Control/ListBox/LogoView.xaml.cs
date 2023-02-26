using FMRookyScouter.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace FMRookyScouter.Control.ListBox
{
    /// <summary>
    /// LogoView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogoView : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private string _imageSource;
        #endregion

        #region Properties
        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public LogoView()
        {
            InitializeComponent();
        }
        #endregion

        private void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is string name))
                return;

            ImageSource = $"/FMRookyScouter;component/Image/Logo/{name.TrimEnglish()}.png";
        }
    }
}
