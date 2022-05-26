using System;
using System.Collections.Generic;

namespace ДемОчка.Models
{
    public partial class Station
    {
        public Station()
        {
            Gas = new HashSet<Gas>();
        }

        public int IdStation { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Gas> Gas { get; set; }
    }
}
