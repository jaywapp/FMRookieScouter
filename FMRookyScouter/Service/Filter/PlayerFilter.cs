using FMRookyScouter.Interface;
using FMRookyScouter.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FMRookyScouter.Service.Filter
{
    public class PlayerFilter 
    {
        public EventHandler ContentChanged;

        public BindingList<IPlayerFilterPattern> Patterns { get; } = new BindingList<IPlayerFilterPattern>();

        public PlayerFilter()
        {
        }

        public IEnumerable<Player> Filtering(IEnumerable<Player> sources)
        {
            if (Patterns == null || !Patterns.Any())
                return sources;

            return sources.Where(src => Patterns.All(p => p.IsMatched(src)));
        }
    }
}
