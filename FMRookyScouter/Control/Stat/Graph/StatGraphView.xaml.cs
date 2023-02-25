using FMRookyScouter.Interface;
using FMRookyScouter.Item;
using SkiaSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace FMRookyScouter.Control.Stat.Graph
{
    /// <summary>
    /// StatGraphView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatGraphView : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Constructor
        public StatGraphView()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is IStat stat))
                return;

            var items = stat.GetItems().ToList();
        }
        #endregion
    }
}
