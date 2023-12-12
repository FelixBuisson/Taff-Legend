using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/Fish", order = 1)]
public class Fishs : ScriptableObject
{
    public float speed = 0.0f;
    public float endurance = 0.0f;
}