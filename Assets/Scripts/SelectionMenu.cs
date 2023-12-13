using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour {

    private static SelectionMenu instance;
    public static SelectionMenu Instance => instance;
    public Fishs fish;
    public FishingRods rod;
    public Baits bait;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GoFish ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}