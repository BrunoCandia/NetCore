using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // 1 jugador tiene 1 equipo
        public virtual Team PlayerTeam { get; set; }
    }
}
