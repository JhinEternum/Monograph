using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LightingPreset", menuName = "LightingPreset", order = 0)]
public class LightingPreset : ScriptableObject
{
    [field: SerializeField] public Gradient AmbientColor { get; private set; }
    [field: SerializeField] public Gradient DirectionalColor { get; private set; }
    [field: SerializeField] public Gradient FogColor { get; private set; }
}
