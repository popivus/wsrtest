using System;
using System.Collections.Generic;

namespace ДемОчка.Models
{
    public partial class Gas
    {
        public int IdGas { get; set; }
        public double Price { get; set; }
        public int AmountOfFuel { get; set; }
        public int GasTypeId { get; set; }
        public int StationId { get; set; }

        public virtual GasType GasType { get; set; } = null!;
        public virtual Station Station { get; set; } = null!;
    }
}
