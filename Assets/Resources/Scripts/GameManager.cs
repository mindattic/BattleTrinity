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