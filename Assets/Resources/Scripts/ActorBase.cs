using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTrinity
{

    public class ActorBase : MonoBehaviour
    {
        protected GameManager GameManager;

        protected SpriteRenderer SpriteRenderer;
        protected Rigidbody2D RigidBody2D;
        protected PolygonCollider2D PolygonCollider2D;

        protected ACTOR_MOVE_STATE CurrentMoveState = ACTOR_MOVE_STATE.Idle;
        protected ACTOR_MOVE_STATE PreviousMoveState = ACTOR_MOVE_STATE.Idle;

        protected float BullRushSpeed = 100f;
        protected Vector3 Direction;
        public GameObject target;
    }
}