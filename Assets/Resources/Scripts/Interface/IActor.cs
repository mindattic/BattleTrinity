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
        string Name { get; }
        GameObject GameObject { get; }
        Rigidbody2D RigidBody2D { get; }
        SpriteRenderer SpriteRenderer { get; }
        PolygonCollider2D PolygonCollider2D { get; }
        ACTOR_MOVE_STATE CurrentMoveState { get; set;}
        ACTOR_MOVE_STATE PreviousMoveState { get; set; }
        bool IsSelectedActor { get; }

        void StopMoving();

    }
}
