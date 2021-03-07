using BattleTrinity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTrinity.Models
{
    public class Team
    {
        public int ID;
        public string Name;
        public List<IActor> Member = new List<IActor>();

        public void Add(IActor actor)
        {
            Member.Add(actor);
        }
        public void Remove(IActor actor)
        {
            Member.Remove(actor);
        }

    }
}
