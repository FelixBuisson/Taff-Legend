using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text display;
    public SelectionMenu stats;

    void Start()
    {
        display.text = "No Stats.";
        stats = SelectionMenu.Instance;
    }

    void Update()
    {
        if (!stats) return;
        if (stats.fish || stats.rod) display.text = "";
        if (stats.fish) display.text += "Fish speed : " + stats.fish.speed.ToString() + '\n'
                                        + "Fish endurance : " + stats.fish.endurance.ToString() + '\n';
        if (stats.rod) display.text += "Hook power : " + stats.rod.power.ToString() + '\n'
                                        + "Hook size : " + stats.rod.size.ToString();
    }
}
