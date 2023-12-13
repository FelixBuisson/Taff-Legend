using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Fishs fish;
    [SerializeField] private FishingRods rod;
    [SerializeField] private Baits bait;
    [SerializeField] private Times time;
    [SerializeField] private Weathers weather;

    private SelectionMenu select;

    void Start()
    {
        select = SelectionMenu.Instance;
    }

    public void Select()
    {
        if (fish) {
            select.fish = fish;
            if (!fish.authorizedTimes.Contains(select.time)) select.time = fish.authorizedTimes[0];
            if (!fish.authorizedWeathers.Contains(select.weather)) select.weather = fish.authorizedWeathers[0];
        }
        if (rod) select.rod = rod;
        if (bait) select.bait = bait;
        if (time && select.fish.authorizedTimes.Contains(time)) select.time = time;
        if (weather && select.fish.authorizedWeathers.Contains(weather)) select.weather = weather;
    }
}