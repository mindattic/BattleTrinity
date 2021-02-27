using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

//https://answers.unity.com/questions/630955/how-to-get-script-component-of-an-object-with-out.html
namespace BattleTrinity.Interface
{
    public interface IActor
    {
        //Properties
        GameObject GameObject { get; }
        Rigidbody2D Rigidbody2D { get; }
        
        SpriteRenderer SpriteRenderer { get; }
    }
}
