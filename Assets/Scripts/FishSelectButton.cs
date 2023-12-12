using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishSelectButton : MonoBehaviour
{
    [SerializeField] private Fishs fish;
    private SelectionMenu select;

    void Start()
    {
        select = SelectionMenu.Instance;
    }

    public void SelectFish()
    {
        select.fish = fish;
    }
}