using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace BattleTrinity
{
    public class CameraManager : MonoBehaviour
    {

        public float FollowDistance;
        public GameObject Target;
        public Vector3 Offset;

        public Vector3 ScrollSpeed;
        public Vector3 FollowSpeed;

        public CAMERA_STATE State = CAMERA_STATE.Scroll;


        //Awake is called when the script instance is being loaded
        private void Awake()
        {
            UnityEngine.Cursor.visible = true;
        }

        //Start() is called just before any of the update methods is called the first time
        private void Start()
        {

        }

        //Update() is called every frame (as often as possible)
        private void Update()
        {
            //Toggle Follow Target
            if (Input.GetKeyDown(KeyCode.F) && Target)
            {
                State = (State == CAMERA_STATE.Follow) ? CAMERA_STATE.Scroll : CAMERA_STATE.Follow;
            }

            if (State == CAMERA_STATE.Follow && Target != null)
            {

            }
            else if (State == CAMERA_STATE.Scroll)
            {
                //Scroll Left/Right
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    Camera.main.transform.Translate(Vector3.right * -ScrollSpeed.x);
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    Camera.main.transform.Translate(Vector3.right * ScrollSpeed.x);

                //Scroll Up/Down
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    Camera.main.transform.Translate(Vector3.up * ScrollSpeed.y);
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    Camera.main.transform.Translate(Vector3.up * -ScrollSpeed.y);

                var scrollWheelDelta = Input.GetAxis("Mouse ScrollWheel");
                if (scrollWheelDelta > 0f)
                {
                    Camera.main.transform.Translate(Vector3.forward * ScrollSpeed.z);
                }
                else if (scrollWheelDelta < 0f)
                {
                    Camera.main.transform.Translate(Vector3.forward * -ScrollSpeed.z);
                }

            }

        }

        //FixedUpdate() is called every fixed framerate frame (once per tick)
        private void FixedUpdate()
        {
            if (Target == null)
                return;

            if (State != CAMERA_STATE.Follow)
                return;

            //Get camera position without Z-axis
            Vector3 posNoZ = transform.position;
            posNoZ.z = Target.transform.position.z;

            //Determine vector between camera and target
            Vector3 targetDirection = (Target.transform.position - posNoZ);

            //Determine interpolation velocity
            float interpolateVelocity = targetDirection.magnitude * Common.CameraDistanceFromZero();

            //Calculate and assign target position
            transform.position = transform.position + (targetDirection.normalized * interpolateVelocity * Time.deltaTime);
            transform.position = Vector3.Slerp(transform.position, transform.position + Offset, 1f);
        }

        public void FollowTarget(GameObject target)
        {
            Target = target;
            State = CAMERA_STATE.Follow;
        }

        public void CenterTarget(GameObject gameObject)
        {
            Target = gameObject;
            var posNoZ = Target.transform.position;
            posNoZ.z = transform.position.z;
            transform.position = posNoZ;
        }



    }
}