﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BattleTrinity.Interface;

namespace BattleTrinity
{

    public class Cursor : MonoBehaviour
    {
        private GameManager GameManager;

        public CURSOR_STATE CursorState = CURSOR_STATE.Pointer;
        private SpriteRenderer SpriteRenderer;
        public Dictionary<string, Sprite> Sprites;

        //Awake is called when the script instance is being loaded
        public void Awake()
        {
            //External components
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            //Internal compoments
            SpriteRenderer = this.GetComponent<SpriteRenderer>();

            //Populate sprite dictionary
            Sprites = new Dictionary<string, Sprite>();
            Sprites.Add("Pointer", (Sprite)Resources.Load("Sprites/pointer", typeof(Sprite)));
            Sprites.Add("Reticle", (Sprite)Resources.Load("Sprites/reticle", typeof(Sprite)));
        }

        //Start() is called just before any of the update methods is called the first time
        public void Start()
        {

        }

        //Update() is called every frame (as often as possible)
        public void Update()
        {
            if (GameManager == null)
                return;

            Plane plane = new Plane(Vector3.forward, 0);

            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                transform.position = ray.GetPoint(distance);
            }

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 point = ray.origin + (ray.direction * Common.CameraDistanceFromZero());
            //point.z = 0f;
            //transform.position = point;


            //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));


            if (Input.GetMouseButtonDown(0))
            {
                // Check if the mouse was clicked over a UI element
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

          
                ExecuteEvents.Execute<ICursorClick>(GameManager.TurnManager.SelectedActor.GameObject, null, (x, y) => x.OnCursorClick());
            }
        }


        //FixedUpdate() is called every fixed framerate frame
        public void FixedUpdate()
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, Common.CameraDistanceFromZero());
        }
    }
}