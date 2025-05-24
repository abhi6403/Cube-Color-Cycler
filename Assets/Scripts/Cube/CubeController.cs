using CubeColorCycler.Color;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeController
    {
        private CubeView _cubeView;

        public CubeController(CubeView cubeView,Vector3 cubePosition,ColorDataSO cubeMaterial)
        {
            _cubeView = GameObject.Instantiate(cubeView,cubePosition,Quaternion.identity);                              // Instantiate a new CubeView at the specified position
            _cubeView.SetCubeController(this);
            SetCubeData(cubeMaterial);
        }

        // Public method to update the cube's color using a ColorDataSO asset
        public void SetCubeData(ColorDataSO material)
        {
            _cubeView.SetCubeData(material);
        }
    }
}
