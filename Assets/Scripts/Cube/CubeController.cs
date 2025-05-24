using CubeColorCycler.Color;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeController
    {
        private CubeView _cubeView;

        public CubeController(CubeView cubeView,Vector3 cubePosition,ColorDataSO cubeMaterial)
        {
            _cubeView = GameObject.Instantiate(cubeView,cubePosition,Quaternion.identity);
            _cubeView.SetCubeController(this);
            SetCubeColor(cubeMaterial);
        }

        public void SetCubeColor(ColorDataSO material)
        {
            _cubeView.SetCubeColor(material);
        }
    }
}
