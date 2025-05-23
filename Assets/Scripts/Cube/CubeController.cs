using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeController
    {
        private CubeView _cubeView;

        public CubeController(CubeView cubeView,Vector3 cubePosition)
        {
            _cubeView = GameObject.Instantiate(cubeView,cubePosition,Quaternion.identity);
            _cubeView.SetCubeController(this);
        }

        public void SetCubeColor(Material material)
        {
            _cubeView.SetCubeColor(material);
        }
    }
}
