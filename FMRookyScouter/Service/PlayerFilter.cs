using FMRookyScouter.Interface;
using FMRookyScouter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMRookyScouter.Service
{
    public class PlayerFilter : IPlayerFilter
    {
        public event EventHandler ConditionChanged;

        private string _namePattern;

        public string NamePattern
        {
            get => _namePattern;
            set
            {
                _namePattern = value;
                ConditionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public IEnumerable<Player> Filtering(IEnumerable<Player> sources)
        {
            if (string.IsNullOrEmpty(NamePattern))
                return sources;

            return sources.Where(s=> s.Common.Name.Contains(NamePattern)).ToList();
        }
    }
}
