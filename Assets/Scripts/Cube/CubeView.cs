using System;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeView : MonoBehaviour
    {
        private CubeController _cubeController;
        
        [SerializeField] private Renderer _cubeMaterial;

        public void SetCubeController(CubeController cubeController)
        {
            _cubeController = cubeController;
        }
        public void SetCubeColor(Material cubeMaterial)
        {
            _cubeMaterial.material.color = cubeMaterial.color;
        }
    }
}
