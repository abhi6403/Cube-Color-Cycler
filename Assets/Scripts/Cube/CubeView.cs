using CubeColorCycler.Color;
using TMPro;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeView : MonoBehaviour
    {
        private CubeController _cubeController;
        
        [SerializeField] private Renderer _cubeMaterial;                                          // The Renderer component used to visually display the cube's material
        [SerializeField] private TextMeshProUGUI _colorText;                                      // Text component for displaying the name of the color/material

        private string _materialName;                                                             // Stores the name of the current material
        
        public void SetCubeController(CubeController cubeController)
        {
            _cubeController = cubeController;
        }

        // Sets the UI text to display the material's name
        private void SetColorText()
        {
            _colorText.text = _materialName;
        }
        
        // Sets the color and name of the cube using a ColorDataSO scriptable object
        public void SetCubeData(ColorDataSO cubeMaterial)
        {
            _cubeMaterial.material.color = cubeMaterial.material.color;
            _materialName = cubeMaterial.material.name;
            SetColorText();
        }
    }
}
