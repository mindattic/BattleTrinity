
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BattleTrinity.Interface;

namespace BattleTrinity
{

    public class Cursor3D : MonoBehaviour
    {
        private GameManager GameManager;

        public CURSOR_STATE CursorState = CURSOR_STATE.Pointer;
        private SpriteRenderer SpriteRenderer;
        private BoxCollider2D BoxCollider2D;

        public Dictionary<string, Sprite> Sprites;

        private float ScaleModifier = 18f;


        private GameObject HoverObject = null;

        //Awake is called when the script instance is being loaded
        public void Awake()
        {
            //External components
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            //Internal compoments
            SpriteRenderer = this.GetComponent<SpriteRenderer>();
            SpriteRenderer.sortingOrder = 2;
            BoxCollider2D = this.GetComponent<BoxCollider2D>();

            //Populate sprite dictionary
            Sprites = new Dictionary<string, Sprite>();
            Sprites.Add("Pointer", (Sprite)Resources.Load("Sprites/pointer", typeof(Sprite)));
            Sprites.Add("PointerRed", (Sprite)Resources.Load("Sprites/pointer-red", typeof(Sprite)));
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

            Plane plane = new Plane(-Vector3.forward, 0);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                transform.position = ray.GetPoint(distance);
            }

            //Modify scale of cursor based on z-distance from Vector3.zero
            float scale = -Camera.main.transform.position.z - ScaleModifier;
            transform.localScale = new Vector3(scale, scale, 0);

            if (Input.GetMouseButtonDown(0))
            {
                if (HoverObject != null)
                {
                    ExecuteEvents.Execute<ICursorClick>(HoverObject, null, (x, y) => x.OnCursorClick());
                }
            }

        }




        //FixedUpdate() is called every fixed framerate frame
        public void FixedUpdate()
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, Common.CameraDistanceFromZero());
        }

        void OnCollisionEnter2D(Collision2D other)
        {

            if (other.gameObject.tag == "Actor")
            {
                HoverObject = other.gameObject;
            }
            else
            {
                HoverObject = null;
            }
        }

    }
}