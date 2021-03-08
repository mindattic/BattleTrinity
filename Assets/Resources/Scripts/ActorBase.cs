using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTrinity
{

    public class ActorBase : MonoBehaviour
    {
        protected GameManager GameManager;

        public SpriteRenderer SpriteRenderer;
        public Rigidbody2D RigidBody2D;
        public PolygonCollider2D PolygonCollider2D;

        public ACTOR_MOVE_STATE CurrentMoveState = ACTOR_MOVE_STATE.Idle;
        public ACTOR_MOVE_STATE PreviousMoveState = ACTOR_MOVE_STATE.Idle;

        public float BullRushSpeed = 100f;
        public Vector3 Direction;
        public GameObject target;
    }
}