using System;
using System.Collections.Generic;
using CubeColorCycler.Cube;
using UnityEngine;

namespace CubeColorCycler.Color
{
    public class ColorManager : MonoBehaviour
    {
        private List<CubeController> _cubeControllers = new List<CubeController>();
        private CubeController _cubeController;
        
        [SerializeField] private int numberOfCubes;
        [SerializeField] private CubeView cubeView;
        [SerializeField] private Vector3 cubePosition;
        [SerializeField] private List<Material> colors;
        [SerializeField] private List<ColorData> cubeColors;

        [Serializable]
        public class ColorData
        {
            public Material material;
            public String name;
        }

        private int _spawnDistance = 6;
        private float _initialWaitTime = 2f;
        private float _waitTime = 3f;
        private float lastChangeTime;
        private bool _isInitialized;
        private void Start()
        {
            for (int i = 0; i < numberOfCubes; i++)
            {
                CreateCube(i);
            }
            
        }

        private void Update()
        {
           CheckTimer();
        }

        private void CheckTimer()
        {
            if (!_isInitialized)
            {
                if (Time.time >= _initialWaitTime)
                {
                    _isInitialized = true;
                }
            }
            
            if (_isInitialized)
            {
                if (Time.time >= lastChangeTime + _waitTime)
                {
                    CycleColors();
                    lastChangeTime = Time.time;
                }
            }
        }
        private void CycleColors()
        {
            if (cubeColors.Count != _cubeControllers.Count || cubeColors.Count < 2)
            {
                return;
            }
            
            ColorData lastMaterial = cubeColors[cubeColors.Count - 1];
            
            for (int i = cubeColors.Count - 1; i > 0; i--)
            {
                cubeColors[i] = cubeColors[i - 1];
            }
            cubeColors[0] = lastMaterial;
            
            for (int i = 0; i < _cubeControllers.Count; i++)
            {
                _cubeControllers[i].SetCubeColor(cubeColors[i]);
            }
        }
        private void CreateCube(int colorNumber)
        {
            _cubeController = new CubeController(cubeView, cubePosition,cubeColors[colorNumber]);
            _cubeControllers.Add(_cubeController);
            IncreasePosition();
        }

        private void IncreasePosition()
        {
            cubePosition += Vector3.right * _spawnDistance;
        }
    }
}