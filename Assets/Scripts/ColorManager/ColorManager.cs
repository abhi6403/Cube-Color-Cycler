using System.Collections.Generic;
using CubeColorCycler.Cube;
using UnityEngine;

namespace CubeColorCycler.Color
{
    public class ColorManager : MonoBehaviour
    {
        private List<CubeController> _cubeControllers = new List<CubeController>();         // List to store all CubeController instances
        private CubeController _cubeController;
        
        [SerializeField] private int numberOfCubes;
        [SerializeField] private CubeView cubeView;
        [SerializeField] private Vector3 cubePosition;                                      // Initial position for spawning cubes
        [SerializeField] private List<ColorDataSO> cubeColors;                              // List of color data to assign to the cubes
        
        private int _spawnDistance = 6;                                                     // Distance between each spawned cube
        private float _initialWaitTime = 2f;                                                // Time to wait before starting color cycling
        private float _waitTime = 3f;                                                       // Time interval between color cycles
        private float lastChangeTime;                                                       // Tracks when the last color cycle occurred
        private bool _isInitialized;                                                        // Indicates if the color cycling logic has been initialized
        
        private void Start()
        {
            // Create the specified number of cubes
            for (int i = 0; i < numberOfCubes; i++)
            {
                CreateCube(i);
            }
        }

        private void Update()
        {
           CheckTimer();
        }

        // Handles the timing logic for when to cycle colors
        private void CheckTimer()
        {
            // Wait for the initial delay before starting the color cycle
            if (!_isInitialized)
            {
                if (Time.time >= _initialWaitTime)
                {
                    _isInitialized = true;
                }
            }
            
            // If initialized, check if it's time to cycle colors again
            if (_isInitialized)
            {
                if (Time.time >= lastChangeTime + _waitTime)
                {
                    CycleColors();
                    lastChangeTime = Time.time;                                              // Update last cycle time           
                }
            }
        }
        
        // Shifts colors between cubes to create a cycling effect
        private void CycleColors()
        {
            if (cubeColors.Count != _cubeControllers.Count || cubeColors.Count < 2)
            {
                return;
            }
            
            // Store the last color to rotate it to the first
            ColorDataSO lastMaterial = cubeColors[cubeColors.Count - 1];
            
            // Shift all colors one position forward
            for (int i = cubeColors.Count - 1; i > 0; i--)
            {
                cubeColors[i] = cubeColors[i - 1];
            }
            cubeColors[0] = lastMaterial;
            
            // Apply the updated colors to all cubes
            for (int i = 0; i < _cubeControllers.Count; i++)
            {
                _cubeControllers[i].SetCubeData(cubeColors[i]);
            }
        }
        
        // Creates a new cube and assigns it a color
        private void CreateCube(int colorNumber)
        {
            _cubeController = new CubeController(cubeView, cubePosition,cubeColors[colorNumber]);
            _cubeControllers.Add(_cubeController);
            IncreasePosition();
        }

        // Increments the spawn position to avoid overlapping cubes
        private void IncreasePosition()
        {
            cubePosition += Vector3.right * _spawnDistance;
        }
    }
}