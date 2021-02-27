using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BattleTrinity.Interface
{
    public interface ICursorClick : IEventSystemHandler
    {
        void OnCursorClick();
    }
}
