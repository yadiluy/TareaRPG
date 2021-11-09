using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { private set; get; }

    public GameObject menuCanvas;
    public GameObject configCanvas;
    public event EventHandler OnMenuOpenEvent;
    public event EventHandler OnMenuCloseEvent;

    private bool menuOpened = false;
    private bool configOpened = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOpened)
        {
            OpenMenu();
            if (configOpened) CloseConfigCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuOpened)
        {
            CloseMenu();
            if (configOpened) CloseConfigCanvas();
        }
    }

    private void OpenMenu()
    {
        if (OnMenuOpenEvent != null)
        {
            // Se notifica a los observadores que sucedio el evento OnMenuOpen
            OnMenuOpenEvent(this, null);
        }
        menuOpened = true;
        menuCanvas.SetActive(true);
    }

    private void CloseMenu()
    {
        if (OnMenuCloseEvent != null)
        {
            // Se notifica a los observadores que sucedio el evento OnMenuClose
            OnMenuCloseEvent(this, null);
        }
        menuOpened = false;
        menuCanvas.SetActive(false);
    }

    public void OpenConfigCanvas()
    {
        configOpened = true;
        menuCanvas.SetActive(false);
        configCanvas.SetActive(true);
    }

    public void CloseConfigCanvas()
    {
        configOpened = false;
        configCanvas.SetActive(false);
        if (menuOpened) CloseMenu();
    }
}
