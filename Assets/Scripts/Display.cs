using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text display;
    public SelectionMenu stats;

    public float speed;
    public float endurance;
    public float power;
    public float size;

    void Start()
    {
        display.text = "No Stats.";
        stats = SelectionMenu.Instance;
    }

    void Update()
    {
        speed = stats.fish.speed + stats.bait.malusSpeed;
        endurance = stats.fish.endurance + stats.bait.malusEndurance;
        power = stats.rod.power + stats.bait.bonusPower;
        size = stats.rod.size + stats.bait.bonusSize;

        if (!stats) return;
        if (stats.fish || stats.rod || stats.bait) display.text = "";
        if (stats.fish || stats.bait) display.text += "Fish speed : " + speed.ToString() + '\n'
                                        + "Fish endurance : " + endurance.ToString() + '\n';
        if (stats.rod || stats.bait) display.text += "Hook power : " + power.ToString() + '\n'
                                        + "Hook size : " + size.ToString();
    }
}
