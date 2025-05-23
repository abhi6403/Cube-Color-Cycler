using System;
using System.Collections.Generic;
using CubeColorCycler.Cube;
using UnityEngine;

namespace CubeColorCycler.Color
{
    public class ColorManager : MonoBehaviour
    {
        private List<CubeController> cubeControllers = new List<CubeController>();
        [SerializeField] private Material[] colors;

        private void Start()
        {
            
        }
        
        
    }
}