using System;
using CubeColorCycler.Color;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace CubeColorCycler.Cube
{
    public class CubeView : MonoBehaviour
    {
        private CubeController _cubeController;
        
        [SerializeField] private Renderer _cubeMaterial;
        [SerializeField] private TextMeshProUGUI _colorText;

        private string _materialName;
        
        public void SetCubeController(CubeController cubeController)
        {
            _cubeController = cubeController;
        }

        private void SetColorText()
        {
            _colorText.text = _materialName;
        }
        public void SetCubeColor(ColorDataSO cubeMaterial)
        {
            _cubeMaterial.material.color = cubeMaterial.material.color;
            _materialName = cubeMaterial.material.name;
            SetColorText();
        }
    }
}
