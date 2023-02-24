using FMRookyScouter.Model;
using System;
using System.Collections.Generic;

namespace FMRookyScouter.Interface
{
    public interface IPlayerFilter
    {
        event EventHandler ConditionChanged;
        IEnumerable<Player> Filtering(IEnumerable<Player> sources);
    }
}
