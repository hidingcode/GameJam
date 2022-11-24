using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Codes.Scripts.PerformanceChecker
{
    public class FPSCounter : MonoBehaviour
    {   
        public TextMeshProUGUI fpsText;
        
        private float pollingTime = 1f;
        private float time;
        private float frameCount;

        private void Update()
        {
            time += Time.unscaledDeltaTime;
            frameCount++;

            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                fpsText.text = frameRate.ToString() + " FPS";

                time -= pollingTime;
                frameCount = 0;
            }
        }
    }
}
