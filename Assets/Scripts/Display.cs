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
        if (!stats.fish) return;

        display.text = "Fish speed : " + stats.fish.speed.ToString() + '\n'
            + "Fish endurance : " + stats.fish.endurance.ToString() + '\n';
                //+ "Hook power : " + stats.hookPower.ToString() + '\n'
                  //  + "Hook size : " + stats.hookSize.ToString();
    }
}
