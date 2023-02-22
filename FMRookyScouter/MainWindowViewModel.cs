using FMRookyScouter.Access;
using ReactiveUI;

namespace FMRookyScouter
{
    public class MainWindowViewModel : ReactiveObject
    {
        public DBAccess Access { get; }

        public MainWindowViewModel()
        {
            Access = new DBAccess();
        }
    }
}
