using FMRookyScouter.Control.Stat.Table;
using FMRookyScouter.Model;
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

namespace FMRookyScouter.Control.Stat.Graph
{
    /// <summary>
    /// PlayerStatGraphView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerStatGraphView : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private UserControl _view;
        #endregion

        #region Properties
        public UserControl View
        {
            get => _view;
            set
            {
                _view = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public PlayerStatGraphView()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is Player player))
                return;

            View = GetView(player);
        }

        private static UserControl GetView(Player player)
        {
            if (player.Goalkeeping.IsGoalkeepper())
                return new GoalkeepperPlayerStatGraphView() { DataContext = player };
            else
                return new FieldPlayerStatGraphView() { DataContext = player };
        }
        #endregion
    }
}
