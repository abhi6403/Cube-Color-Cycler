using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeController
    {
        private CubeView _cubeView;

        public CubeController(CubeView cubeView,Vector3 cubePosition,Material cubeMaterial)
        {
            _cubeView = GameObject.Instantiate(cubeView,cubePosition,Quaternion.identity);
            _cubeView.SetCubeController(this);
            SetCubeColor(cubeMaterial);
        }

        public void SetCubeColor(Material material)
        {
            _cubeView.SetCubeColor(material);
        }
    }
}
