﻿using BattleTrinity.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleTrinity
{
    public class GameManager : MonoBehaviour
    {

        public CameraManager CameraManager;

    

        public float Speed = 1.0f;

        public bool IsPaused = false;

        public GameObject ActiveActor;



        //Awake is called when the script instance is being loaded
        private void Awake()
        {
            //CameraManager = (CameraManager)GameObject.Find("Main Camera\\CameraManager").GetComponent("CameraManager");
            ActiveActor = GameObject.Find("knight-02");
        }

        //Start() is called just before any of the update methods is called the first time
        private void Start()
        {
   
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