using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public MenuManager menuManager;
    public float Health { get; set; }

    private float movementX;
    private float movementY;

    public bool CanMove { get; set; }

    private void Awake()
    {
        Health = 3f;
        CanMove = true;
        // Nos vamos a inscribir como observadores de MenuManager (OnMenuOpenEvent)
        menuManager.OnMenuOpenEvent += MenuManager_OnMenuOpenEvent;
        // Nos vamos a inscribir como observadores de MenuManager (OnMenuCloseEvent)
        menuManager.OnMenuCloseEvent += MenuManager_OnMenuCloseEvent;
    }

    private void MenuManager_OnMenuCloseEvent(object sender, System.EventArgs e)
    {
        CanMove = true;
    }

    private void MenuManager_OnMenuOpenEvent(object sender, System.EventArgs e)
    {
        CanMove = false;
    }

    private void Update()
    {
        if (CanMove)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            movementY = Input.GetAxisRaw("Vertical");

            transform.position += (new Vector3(movementX, movementY)) * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Character"))
        {
            if (collision.gameObject.name == "Princess")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(1);
            }

            if (collision.gameObject.name == "Dog1")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(2);
            }

            if (collision.gameObject.name == "Dog2")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(3);
            }

            if (collision.gameObject.name == "Villain")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(4);
            }

            if (collision.gameObject.name == "RigidForest")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(5);
            }
        }

    }
}
