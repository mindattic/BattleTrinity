﻿using BattleTrinity.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTrinity
{
    public class Actor : ActorBase, IActor, ICursorClick
    {
        //Interface properties
        string IActor.Name { get => name; }
        GameObject IActor.GameObject { get => gameObject; }
        Rigidbody2D IActor.RigidBody2D { get => RigidBody2D; }
        SpriteRenderer IActor.SpriteRenderer { get => SpriteRenderer; }
        PolygonCollider2D IActor.PolygonCollider2D { get => PolygonCollider2D; }

        bool IsSelectedActor { get => name == GameManager.TurnManager.SelectedActor.Name; }

        //Awake is called when the script instance is being loaded
        void Awake()
        {
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            RigidBody2D = this.GetComponent<Rigidbody2D>();
            SpriteRenderer = this.GetComponent<SpriteRenderer>();          
            PolygonCollider2D = this.GetComponent<PolygonCollider2D>();
        }

        //Start() is called just before any of the update methods is called the first time
        void Start()
        {
            if (target == null)
                return;

            Direction = this.transform.position.DirectionTo(target.transform.position);
        }

        //Update() is called every frame (as often as possible)
        void Update()
        {
            CheckBullRush();
            CheckMoving();
            CheckIdle();

            PreviousMoveState = CurrentMoveState;
        }

        //FixedUpdate() is called every fixed framerate frame
        public void FixedUpdate()
        {
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

        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "Actor")
            {
                if (CurrentMoveState == ACTOR_MOVE_STATE.BullRush)
                {
                    StopMoving();
                }
                else if (CurrentMoveState == ACTOR_MOVE_STATE.Idle)
                {
                    Bounce(other);
                }
            }
        }


        private void StopMoving()
        {
            CurrentMoveState = ACTOR_MOVE_STATE.Idle;
            RigidBody2D.velocity = Vector3.zero;
            RigidBody2D.angularVelocity = 0f;
        }

        private void Bounce(Collision2D other)
        {
            other.gameObject.GetComponent<Actor>().CurrentMoveState = ACTOR_MOVE_STATE.Moving;
            Vector2 bounce = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            RigidBody2D.AddForce(other.contacts[0].normal * bounce);
        }

        public void OnCursorClick()
        {
            GameManager.TurnManager.SetSelectedActor(name);
        }


    }
}