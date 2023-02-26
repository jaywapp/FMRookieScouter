using FMRookyScouter.Model;

namespace FMRookyScouter.Interface
{
    public interface IPlayerFilterPattern
    {
        bool IsMatched(Player player);
    }
}
