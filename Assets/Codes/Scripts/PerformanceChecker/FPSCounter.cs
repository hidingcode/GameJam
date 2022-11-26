using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Codes.Scripts.PerformanceChecker
{
    public class FPSCounter : MonoBehaviour
    {   
        public TextMeshProUGUI fpsText;
        
        private readonly float _pollingTime = 1f;
        private float _time;
        private float _frameCount;

        private void Update()
        {
            _time += Time.unscaledDeltaTime;
            _frameCount++;

            if (_time >= _pollingTime)
            {
                int frameRate = Mathf.RoundToInt(_frameCount / _time);
                fpsText.text = frameRate.ToString() + " FPS";

                _time -= _pollingTime;
                _frameCount = 0;
            }
        }
    }
}
