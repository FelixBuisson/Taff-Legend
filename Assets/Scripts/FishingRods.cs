using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Rod", menuName = "ScriptableObjects/Rod", order = 1)]

public class FishingRods : ScriptableObject
{
    public float power = 0.0f;
    public float size = 0.0f;
}