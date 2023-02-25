using FMRookyScouter.Interface;
using FMRookyScouter.Item;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FMRookyScouter.Control.Stat
{
    /// <summary>
    /// StatView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatView : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private string _title;
        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public StatView()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is IStat stat))
                return;

            Title = stat.GetType().Name;
        }
        #endregion
    }
}
