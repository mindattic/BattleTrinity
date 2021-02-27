using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTrinity
{
    public class Actor : ActorBase
    {

        void Awake()
        {
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            SpriteRenderer = this.GetComponent<SpriteRenderer>();
            RigidBody2D = this.GetComponent<Rigidbody2D>();
            PolygonCollider2D = this.GetComponent<PolygonCollider2D>();

        }

        // Start is called before the first frame update
        void Start()
        {
            if (target == null)
                return;

            Direction = this.transform.position.DirectionTo(target.transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            CheckBullRush();
            CheckMoving();
            CheckIdle();

            PreviousMoveState = CurrentMoveState;
        }


        private void CheckBullRush()
        {
            if (CurrentMoveState == ACTOR_MOVE_STATE.BullRush)
            {
                RigidBody2D.AddForce(Direction * BullRushSpeed);
            }
            else if (CurrentMoveState == ACTOR_MOVE_STATE.Idle && PreviousMoveState == ACTOR_MOVE_STATE.BullRush)
            {
                RigidBody2D.velocity = Vector3.zero;
                RigidBody2D.angularVelocity = 0f;
            }
        }

        private void CheckMoving()
        {

        }


        private void CheckIdle()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (CurrentMoveState == ACTOR_MOVE_STATE.BullRush)
            {
                StopMoving();
            }
            else if (CurrentMoveState == ACTOR_MOVE_STATE.Idle)
            {
                Bounce(collision);
            }
        }


        private void StopMoving()
        {
            CurrentMoveState = ACTOR_MOVE_STATE.Idle;
            RigidBody2D.velocity = Vector3.zero;
            RigidBody2D.angularVelocity = 0f;
        }

        private void Bounce(Collision2D collision)
        {
            collision.gameObject.GetComponent<Actor>().CurrentMoveState = ACTOR_MOVE_STATE.Moving;
            Vector2 bounce = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            RigidBody2D.AddForce(collision.contacts[0].normal * bounce);
        }


    }
}