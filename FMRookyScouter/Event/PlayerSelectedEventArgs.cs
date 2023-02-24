using FMRookyScouter.Model;
using System;

namespace FMRookyScouter.Event
{
    public class PlayerSelectedEventArgs : EventArgs
    {
        public Player Seleted { get; }

        public PlayerSelectedEventArgs(Player player)
        {
            Seleted = player;
        }
    }
}
