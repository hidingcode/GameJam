using UnityEngine;

namespace Codes.Scripts
{
    public class CameraSwitch : MonoBehaviour
    {   
        [SerializeField] private Camera[] cameras;
        private bool _canCameraMove;
        
        // Start is called before the first frame update
        void Start()
        {
            DisableAllCameras();
            EnableCamera(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DisableAllCameras();
                EnableCamera(0);
                SetCameraMovement(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DisableAllCameras();
                EnableCamera(1);
                SetCameraMovement(false);
            }
        }

        private void DisableAllCameras()
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].enabled = true;
                cameras[i].tag = "MainCamera";
            }
        }

        private void EnableCamera(int index)
        {
            cameras[index].enabled = false;
            cameras[index].tag = "Untagged";
        }
        
        private void SetCameraMovement(bool _canCameraMove)
        {
            cameras[1].enabled = _canCameraMove;
        }
    }
}
