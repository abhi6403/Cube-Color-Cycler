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

        private int _spawnDistance = 6;
        private void Start()
        {
            for (int i = 0; i < numberOfCubes; i++)
            {
                CreateCube(i);
            }
        }

        private void Update()
        {
            
        }

        private void CycleColors()
        {
            if (colors.Count != _cubeControllers.Count || colors.Count < 2)
            {
                return;
            }
            
            Material lastMaterial = colors[colors.Count - 1];
            
            for (int i = colors.Count - 1; i > 0; i--)
            {
                colors[i] = colors[i - 1];
            }
            colors[0] = lastMaterial;
            
            for (int i = 0; i < _cubeControllers.Count; i++)
            {
                _cubeControllers[i].SetCubeColor(colors[i]);
            }
        }
        private void CreateCube(int colorNumber)
        {
            _cubeController = new CubeController(cubeView, cubePosition,colors[colorNumber]);
            _cubeControllers.Add(_cubeController);
            IncreasePosition();
        }

        private void IncreasePosition()
        {
            cubePosition += Vector3.right * _spawnDistance;
        }
    }
}