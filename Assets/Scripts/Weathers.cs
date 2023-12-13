using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weather", menuName = "ScriptableObjects/Weather", order = 1)]

public class Weathers : ScriptableObject
{
    public bool Clear = false;
    public bool Cloudy = false;
    public bool Rainy = false;
    public bool Stormy = false;
}