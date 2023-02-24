using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FMRookyScouter.Control.ListBox
{
    /// <summary>
    /// PositionsView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PositionsView : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private string _displayPositions;
        #endregion

        #region Properties
        public string DisplayPositions
        {
            get => _displayPositions;
            set
            {
                _displayPositions = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public PositionsView()
        {
            InitializeComponent();
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is ePosition[] value))
                return;

            DisplayPositions = string.Join(" / ", value);
        }
    }
}
