using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { private set; get; }
    public string heroName { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        heroName = "Héroe";
    }

    public void UpdateHeroName(string name)
    {
        heroName = name;
    }
}
