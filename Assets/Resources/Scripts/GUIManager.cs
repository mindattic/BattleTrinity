﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTrinity
{
    public class GUIManager : MonoBehaviour
    {
        private GameManager GameManager;
        private Cursor3D Cursor;

        private float DeltaTime = 0.0f;
        private Font Consolas;
        public float LineSpacing;

        private Button Skill01;
        private Button Skill02;
        private Button Skill03;

        //public bool IsReady
        //{
        //    get => (GameManager != null);
        //}

        //Awake is called when the script instance is being loaded
        private void Awake()
        {
            //Resources
            Consolas = (Font)Resources.Load("Font/Consolas", typeof(Font));

            //External components
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
            Cursor = (Cursor3D)GameObject.Find("Cursor3D").GetComponent("Cursor");

            //Internal components
            Skill01 = GameObject.Find("Skill-01").GetComponent<Button>();
            Skill01.onClick.AddListener(OnSkill01Click);

            Skill02 = GameObject.Find("Skill-02").GetComponent<Button>();
            Skill02.onClick.AddListener(OnSkill02Click);

            Skill03 = GameObject.Find("Skill-03").GetComponent<Button>();
            Skill03.onClick.AddListener(OnSkill03Click);

            LineSpacing = (Screen.height * 0.03f);    
        }

        //Start() is called just before any of the update methods is called the first time
        private void Start()
        {

        }

        //Update() is called every frame (as often as possible)
        private void Update()
        {
            DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
        }

        //FixedUpdate() is called every fixed framerate frame (once per tick)
        private void FixedUpdate()
        {

        }

        public void OnSkill01Click()
        {
            //if (!IsReady)
            //    return;

        }


        public void OnSkill02Click()
        {
            //if (!IsReady)
            //    return;

        }

        public void OnSkill03Click()
        {
            //if (!IsReady)
            //    return;

        }


        //OnGUI() is called to handle GUI events
        private void OnGUI()
        {
            //if (!IsReady)
            //    return;

  
            GUI.skin.font = Consolas;

            GUI.Label(new Rect(10, Screen.height - (LineSpacing * 13), 1000, 32), $"          Running Time: " + Time.time.ToString("0.##") + " seconds");
            GUI.Label(new Rect(10, Screen.height - (LineSpacing * 12), 1000, 32), $"                Camera: " + Camera.main.transform.position.ToString());
            GUI.Label(new Rect(10, Screen.height - (LineSpacing * 11), 1000, 32), $"                   FPS: {(1.0f / DeltaTime).ToString("0.##")}");
            //GUI.Label(new Rect(10, Screen.height - (LineSpacing * 10), 1000, 32), $"          Current Turn: {GameManager.TurnManager.SelectedActor.Name}");



        }
    }

}