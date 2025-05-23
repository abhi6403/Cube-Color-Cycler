using System;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeView : MonoBehaviour
    {
        private CubeController _cubeController;
        
        private Material _cubeMaterial;

        private void Start()
        {
            _cubeMaterial = GetComponent<Renderer>().material;
        }

        public void SetCubeController(CubeController cubeController)
        {
            _cubeController = cubeController;
        }
        public void SetCubeColor(Material cubeMaterial)
        {
            _cubeMaterial = cubeMaterial;
        }
    }
}
