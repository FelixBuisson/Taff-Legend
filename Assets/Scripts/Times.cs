using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Time", menuName = "ScriptableObjects/Time", order = 1)]

public class Times : ScriptableObject
{
    public bool Day = false;
    public bool Night = false;
}