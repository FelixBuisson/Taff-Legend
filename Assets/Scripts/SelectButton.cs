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
    private SelectionMenu select;

    void Start()
    {
        select = SelectionMenu.Instance;
    }

    public void Select()
    {
        if (fish) select.fish = fish;
        if (rod) select.rod = rod;
        if (bait) select.bait = bait;
    }
}