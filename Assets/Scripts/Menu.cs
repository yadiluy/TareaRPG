using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private int currentMenuPosition;

    private List<Button> menus = new List<Button>();

    private void Start()
    {
        menus.Add(transform.Find("Panel").Find("ButConfig").GetComponent<Button>());
        menus.Add(transform.Find("Panel").Find("ButRestart").GetComponent<Button>());
        menus.Add(transform.Find("Panel").Find("ButQuit").GetComponent<Button>());

        currentMenuPosition = 0;

        //menus[currentMenuPosition].Select();
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Debug.Log(currentMenuPosition);
        //    if (currentMenuPosition > 0)
        //    {
        //        currentMenuPosition--;
        //    }
        //    menus[currentMenuPosition].Select();
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    if (currentMenuPosition < menus.Count - 1)
        //    {
        //        currentMenuPosition++;
        //    }
        //    menus[currentMenuPosition].Select();
        //}
    }
}
