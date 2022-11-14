using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class UtilsClass
    {
        // Get the length (scale X) of game object
        public static float GetGameObjectLength(GameObject gObject)
        {
            return GetGameObjectSize(gObject).x;
        }

        // Get the height (scale Y) of game object
        public static float GetGameObjectHeight(GameObject gObject)
        {   
            return GetGameObjectSize(gObject).y;
        }

        // Get the width (scale Z) of game object
        public static float GetGameObjectWIdth(GameObject gObject)
        {
            return GetGameObjectSize(gObject).z;
        }

        // Get the size of the game object
        public static Vector3 GetGameObjectSize(GameObject gObject)
        {
            Vector3 size = gObject.GetComponent<Collider>().bounds.size;
            return size;
        }

        // Get Mouse Position in World with Z = 0f (Only works ib 2D)
        public static Vector3 GetMouseWorldPosWithoutZ()
        {
            Vector3 vec = GetMouseWorldPos(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        // (Only works in 2D)
        public static Vector3 GetMouseWorldPos()
        {
            return GetMouseWorldPos(Input.mousePosition, Camera.main);
        }

        // (Only works in 2D)
        public static Vector3 GetMouseWorldPos(Camera worldCamera)
        {
            return GetMouseWorldPos(Input.mousePosition, worldCamera);
        }

        // (Only works in 2D)
        public static Vector3 GetMouseWorldPos(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }
    }
}


