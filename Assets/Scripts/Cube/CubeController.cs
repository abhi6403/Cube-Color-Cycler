using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeController
    {
        private CubeView _cubeView;

        public CubeController(CubeView cubeView)
        {
            _cubeView = GameObject.Instantiate(cubeView);
            _cubeView.SetCubeController(this);
        }

        public void SetCubeColor(Material material)
        {
            _cubeView.SetCubeColor(material);
        }
    }
}
