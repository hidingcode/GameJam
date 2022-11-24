using System;
using UnityEngine;
using Codes.Scripts.Utils;

namespace Codes.Scripts
{
    public class Spawner : MonoBehaviour
    {   
        [Tooltip("Please use the game objects from the hierarchy for the script to work")]
        public GameObject[] objectsToSpawn;
        private int _objectIndex = 0;
        private float _offsetY;
        
        [Tooltip("Determine whether the spawner can spawn an object or not")]
        [SerializeField] private bool canSpawn = true;
        [Tooltip("The time interval between each spawn")]
        public float timeToSpawn;
        private float _currentTimeToSpawn;
        
        // Update is called once per frame
        void Update()
        {   
            _offsetY = UtilsClass.GetGameObjectHeight(objectsToSpawn[_objectIndex])/ 2;

            if (canSpawn)
            {   
                UpdateTimer();
            }
        }
        
        // Spawn an object with offset in y axis at the position of the spawner
        public void SpawnObject(GameObject obj, float offsetY)
        {   
            Vector3 position = transform.position;
            Vector3 posWithOffset = new Vector3(position.x , offsetY, position.z);
            Instantiate(obj, posWithOffset, Quaternion.identity);
        }
        
        // Spawn an object at the position of the spawner
        public void SpawnObject(GameObject obj)
        {
            Instantiate(objectsToSpawn[_objectIndex], transform.position, Quaternion.identity);
        }

        // Update the timer to spawn an object
        private void UpdateTimer()
        {
            if (_currentTimeToSpawn > 0)
            {
                _currentTimeToSpawn -= Time.deltaTime;
            }
            else
            {   
                SpawnObject(objectsToSpawn[_objectIndex], _offsetY);
                _currentTimeToSpawn = timeToSpawn;
            }
        }
        
        // Set the object to be spawned by the spawner
        public void SetObjectIndex(int index)
        {
            _objectIndex = index;
        }
        
        // Get the current spawn object
        public int GetObjectIndex()
        {
            return _objectIndex;
        }
        
        // Make the spawner to spawn or not
        public void SetCanSpawn(bool canSpawn)
        {
            this.canSpawn = canSpawn;
        }
        
        // Get whether the game object can be spawn or not
        public bool GetCanSpawn()
        {
            return canSpawn;
        }
    }
}
