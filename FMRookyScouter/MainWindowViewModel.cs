using FMRookyScouter.Access;
using FMRookyScouter.View;
using ReactiveUI;
using System.Linq;

namespace FMRookyScouter
{
    public class MainWindowViewModel : ReactiveObject
    {
        public DBAccess Access { get; }

        public PlayersViewModel PlayersViewModel { get; }

        public MainWindowViewModel()
        {
            Access = new DBAccess();
            PlayersViewModel = new PlayersViewModel(Access.Sessons.Values.FirstOrDefault());
        }
    }
}
