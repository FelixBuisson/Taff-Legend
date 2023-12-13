using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Bait", menuName = "ScriptableObjects/Bait", order = 1)]

public class Baits : ScriptableObject
{
    public float malusSpeed = 0.0f;
    public float malusEndurance = 0.0f;
    public float bonusPower = 0.0f;
    public float bonusSize = 0.0f;
}