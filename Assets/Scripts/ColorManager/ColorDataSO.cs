using System;
using UnityEngine;

namespace CubeColorCycler.Color
{
    [CreateAssetMenu(fileName = "ColorData", menuName = "Scriptable Objects/ColorData")]

    public class ColorDataSO : ScriptableObject
    {
        public Material material;
        public String name;
    }
}
