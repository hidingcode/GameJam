using UnityEngine;

namespace Codes.Scripts
{
    public class Projectile : MonoBehaviour
    {   
        public float projectileSpeed = 10f;
        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * (projectileSpeed * Time.deltaTime);
        }
    }
}
