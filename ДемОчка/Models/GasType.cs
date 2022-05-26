using System;
using System.Collections.Generic;

namespace ДемОчка.Models
{
    public partial class GasType
    {
        public GasType()
        {
            Gas = new HashSet<Gas>();
        }

        public int IdGasType { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Gas> Gas { get; set; }
    }
}
