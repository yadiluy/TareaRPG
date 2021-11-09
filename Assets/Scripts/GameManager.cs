using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    public GameObject canvasIntro;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndIntro()
    {
        canvasIntro.SetActive(false);
    }
}
