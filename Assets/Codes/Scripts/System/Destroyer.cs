using UnityEngine;

namespace Codes.Scripts.System
{
    public class Destroyer : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
        
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            if (other.gameObject.CompareTag("Object"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
