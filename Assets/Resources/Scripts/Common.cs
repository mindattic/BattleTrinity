using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace BattleTrinity
{
    public static class Common
    {
        private static UnityEngine.Random random = new UnityEngine.Random();

        public static Exception Exception(string error)
        {
            return new Exception(string.Format("[ERROR] => {0}::{1}",
                new StackTrace().GetFrame(1).GetMethod().ToString(),
                error));
        }

        public static void Shutdown()
        {
            DestroyGameObjectsByTag(Constants.TAG_CONTROLLER_OBJECT);
            DestroyGameObjectsByTag(Constants.TAG_PLAYER);
            // Debug.Log(string.Format("Application ended after {0} seconds", Time.time));
        }

        public static Vector3 MoveTowards(Transform t1, Transform t2, float moveSpeed)
        {
            return Vector3.MoveTowards(t1.position, t2.position, moveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="t2"></param>
        /// <param name="rotateSpeed"></param>
        /// <param name="linearInterpolation">
        /// Slerp is a spherical linear interpolation. The interpolation is mapped as though on a quarter segment of a circle so you get the slow out and slow in effect. 
        /// The distance between each step *IS NOT* equidistant.
        /// 
        /// Lerp is a linear interpolation so that the distant between each step is equal across the entire interpolation.
        /// The distance between each step *IS* equidistant.
        /// 
        /// https://forum.unity.com/threads/what-is-the-difference-of-quaternion-slerp-and-lerp.101179/
        /// </param>
        /// <returns></returns>
        public static Quaternion RotateTowards(Transform transform, Vector3 target, float rotateSpeed, bool linearInterpolation = false)
        {
            if (rotateSpeed == 0f)
                return transform.rotation;

            Vector3 targetDirection = target - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            if (linearInterpolation)
                return Quaternion.Lerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
            else
                return Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
        }

        public static Vector3 DirectionTo(this Vector2 to, Vector2 from)
        {
            return (from - to);
        }

        public static Vector3 DirectionTo(this Vector3 to, Vector3 from)
        {
            return (from - to);
        }


        public static bool IsFacingPosition(Transform a, Vector3 b, float tolerance = 0.98f)
        {
            //Vector3 dirFromAtoB = (b - a.position).normalized;
            //float dotProd = Vector3.Dot(dirFromAtoB, a.right);

            //return (dotProd > tolerance); // a is looking mostly towards b


            float dot = Vector3.Dot(a.right, (b - a.position).normalized);
            return (dot > tolerance);
        }

        //DEBUG
        public static Quaternion RotateTowards2(Transform t1, Transform t2, float rotateSpeed, bool linearInterpolation = false)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = t1.position - t2.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(t1.forward, targetDirection, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            return Quaternion.Euler(newDirection);
        }

        public static Vector3 GetPointBetween(Transform t1, Transform t2, float offset = 0)
        {
            //get the positions of our transforms
            Vector3 pos1 = t1.position;
            Vector3 pos2 = t2.position;

            //get the direction between the two transforms -->
            Vector3 dir = (pos2 - pos1).normalized;

            //get a direction that crosses our [dir] direction
            //NOTE! : this can be any of a buhgillion directions that cross our [dir] in 3D space
            //To alter which direction we're crossing in, assign another directional value to the 2nd parameter
            Vector3 perpDir = Vector3.Cross(dir, Vector3.right);

            //get our midway point
            Vector3 midPoint = (pos1 + pos2) / 2f;

            //get the offset point
            //This is the point you're looking for.
            Vector3 offsetPoint = midPoint + (perpDir * offset);

            return offsetPoint;
        }


        /// <summary>
        /// Calculates the distance the camera is from 0 on the Z-axis
        /// </summary>
        /// <returns></returns>
        public static float CameraDistanceFromZero()
        {
            return Mathf.Abs(Camera.main.transform.position.z);
        }

        public static GameObject[] FindGameObjectsByTags(string[] tags)
        {
            List<GameObject> combinedList = new List<GameObject>();
            for (int i = 0; i < tags.Length; i++)
            {
                GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tags[i]);
                combinedList.AddRange(taggedObjects);
            }
            return combinedList.ToArray();
        }

        public static void DestroyGameObjectsByTag(string tag, int exceptionLayer = Constants.LAYER_TOOLBOX)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

            if (gameObjects != null && gameObjects.Length > 0)
            {
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i].layer != exceptionLayer)
                        GameObject.DestroyImmediate(gameObjects[i]);
                }
            }
        }




        public static void DisableCameras()
        {
            Camera[] cameras = GameObject.FindObjectsOfType<Camera>();

            if (cameras != null && cameras.Length > 0)
            {
                for (var i = 0; i < cameras.Length; i++)
                {
                    cameras[i].enabled = false;
                }
            }
        }

        public static float GetRandomInteger(int min, int max)
        {
            return (int)UnityEngine.Random.Range(min, max);
        }

        public static float GetRandomFloat(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// Determines whether a point (a) is near another point (b) within a certain range (r)
        /// </summary>
        public static bool IsInRange(float a, float b, float r)
        {
            return (a <= b + r && a >= b - r);
        }

        /// <summary>
        /// Determines whether a point (a) is near another point (b) within a certain range (r)
        /// </summary>
        public static bool IsInRange(Vector3 a, Vector3 b, float r)
        {
            return ((a.x <= b.x + r && a.x >= b.x - r)
                && (a.y <= b.y + r && a.y >= b.y - r)
                && (a.z <= b.z + r && a.z >= b.z - r));
        }

        public static Vector2 FindNearestPointOnLineInfinite(Vector2 origin, Vector2 direction, Vector2 point)
        {
            direction.Normalize();
            Vector2 lhs = point - origin;

            float dotP = Vector2.Dot(lhs, direction);
            return origin + direction * dotP;
        }

        public static Vector2 FindNearestPointOnLine(Vector2 origin, Vector2 end, Vector2 point)
        {
            //Get heading
            Vector2 heading = (end - origin);
            float magnitudeMax = heading.magnitude;
            heading.Normalize();

            //Do projection from the point but clamp it
            Vector2 lhs = point - origin;
            float dotP = Vector2.Dot(lhs, heading);
            dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);
            return origin + heading * dotP;
        }

        //public static Vector2 RandomPosition()
        //{
        //    return new Vector2(Random.Range(0, borders.width), Random.Range(0, borders.height));
        //}

        /// <summary>
        /// Determines if number is even or not
        /// </summary>
        public static bool IsEven(int n)
        {
            return (n % 2 == 0);
        }


        /// <summary>
        /// Recursively sets GameObject's layer to newLayer
        /// </summary>
        /// <param name="layerNumber">The new layer</param>
        /// <param name="trans">Start transform</param>
        public static void SetLayer(Transform trans, int layerNumber)
        {
            trans.gameObject.layer = layerNumber;
            foreach (Transform child in trans)
            {
                child.gameObject.layer = layerNumber;
                if (child.childCount > 0)
                {
                    SetLayer(child.transform, layerNumber);
                }
            }
        }

    }

}