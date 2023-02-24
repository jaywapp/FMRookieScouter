using FMRookyScouter.Model;
using System.Windows;

namespace FMRookyScouter.Dialog
{
    /// <summary>
    /// PlayerAnalysisDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerAnalysisDialog : Window
    {
        public Player Player { get; }

        public PlayerAnalysisDialog(Player player)
        {
            Player = player;
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
