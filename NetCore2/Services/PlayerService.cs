using NetCore2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Services
{
    public class PlayerService : IPlayerService
    {
        public string GetName()
        {
            return "Juan Perez";
        }
    }
}
