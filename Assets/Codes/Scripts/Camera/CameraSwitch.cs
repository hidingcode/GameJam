using UnityEngine;

namespace Codes.Scripts
{
    public class CameraSwitch : MonoBehaviour
    {   
        [SerializeField] private Camera[] cameras;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].enabled = false;
                cameras[i].tag = "Untagged";
            }
            cameras[0].enabled = true;
            cameras[0].tag = "MainCamera";
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                for (int i = 0; i < cameras.Length; i++)
                {
                    cameras[i].enabled = false;
                    cameras[i].tag = "Untagged";
                }
                cameras[0].enabled = true;
                cameras[0].tag = "MainCamera";               
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                for (int i = 0; i < cameras.Length; i++)
                {
                    cameras[i].enabled = false;
                    cameras[i].tag = "Untagged";
                }
                cameras[1].enabled = true;
                cameras[1].tag = "MainCamera";
            }
        }
    }
}
