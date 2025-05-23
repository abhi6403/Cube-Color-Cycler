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
        [SerializeField] private Material[] colors;

        private int _spawnDistance = 6;
        private void Start()
        {
            for (int i = 0; i < numberOfCubes; i++)
            {
                CreateCube();
            }
        }

        private void CreateCube()
        {
            _cubeController = new CubeController(cubeView, cubePosition);
            _cubeControllers.Add(_cubeController);
            IncreasePosition();
        }

        private void IncreasePosition()
        {
            cubePosition += Vector3.right * _spawnDistance;
        }
    }
}