using BattleTrinity.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleTrinity
{
    public class GameManager : MonoBehaviour
    {

        public CameraManager CameraManager;
        public TurnManager TurnManager;

        public float Speed = 1.0f;
        public bool IsPaused = false;

        //Awake is called when the script instance is being loaded
        private void Awake()
        {
            //External components
            CameraManager = (CameraManager)GameObject.Find("Main Camera").GetComponent("CameraManager");
            TurnManager = (TurnManager)GameObject.Find("TurnManager").GetComponent("TurnManager");
        }

        //Start() is called just before any of the update methods is called the first time
        private void Start()
        {
            Cursor.visible = false;
        }

        //Update() is called every frame (as often as possible)
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                IActor knight01 = (IActor)GameObject.Find("knight-01").GetComponent("Actor");
                knight01.StopMoving();
                knight01.GameObject.transform.position = new Vector3(-26.9f, -13.4f, 0f);
                knight01.CurrentMoveState = ACTOR_MOVE_STATE.Idle;
                knight01.PreviousMoveState = ACTOR_MOVE_STATE.Idle;
                

                IActor knight02 = (IActor)GameObject.Find("knight-02").GetComponent("Actor");
                knight02.StopMoving();
                knight02.GameObject.transform.position = new Vector3(-79.3f, -54.7f, 0f);
                knight02.CurrentMoveState = ACTOR_MOVE_STATE.BullRush;
                knight02.PreviousMoveState = ACTOR_MOVE_STATE.Idle;

                IActor knight03 = (IActor)GameObject.Find("knight-03").GetComponent("Actor");
                knight03.StopMoving();
                knight03.GameObject.transform.position = new Vector3(0f, -6f, 0f);
                knight03.CurrentMoveState = ACTOR_MOVE_STATE.Idle;
                knight03.PreviousMoveState = ACTOR_MOVE_STATE.Idle;
            }


        }

        //FixedUpdate() is called every fixed framerate frame (once per tick)
        private void FixedUpdate()
        {

        }

        private void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = (!IsPaused) ? 1 : 0; //https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
        }


    }
}