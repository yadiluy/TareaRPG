using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    public MenuManager menuManager;
    public GameObject basicArrowPrefab;
    public GameObject magicArrowPrefab;
    public GameObject GoblinHealth;
    public EnemyController enemy;
    public Text health;

    private Rigidbody2D rb;
    private Animator animator;
    private float movementX;
    private float movementY;
    private bool onBasicArrow = true;
    private float heroHealth = 5f;

    private float hf = 0.0f;
    private float vf = 0.0f;

    public bool CanMove { get; set; }

    private void Awake()
    {
        CanMove = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

            hf = movementX > 0.01f ? movementX : movementX < -0.01f ? 1 : 0;
            vf = movementY > 0.01f ? movementY : movementY < -0.01f ? 1 : 0;
            if (movementX < -0.01f)
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movementX > 0.01f || movementY != 0)
            {
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }

            animator.SetFloat("Horizontal", hf);
            animator.SetFloat("Vertical", movementY);
            animator.SetFloat("Speed", vf);

            transform.position += (new Vector3(movementX, movementY)) * Time.deltaTime * speed;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (movementX > 0.01f)
                {
                    Fire(180f);
                }
                else if (movementY > 0.01)
                {
                    Fire(-90f);
                }
                else if (movementY < -0.01f)
                {
                    Fire(90f);
                }
                else if (movementX < -0.01f)
                {
                    Fire(0f);
                }
                else
                {
                    Fire(90f);
                }
            }
            if (Input.GetKey(KeyCode.Tab))
            {
                SwapWeapon();
            }
            if (heroHealth <= 0)
            {
                GameManager.Instance.Restart();
            }
        }

        if (transform.position.x > 45f)
        {
            GoblinHealth.SetActive(true);
            enemy.active = true;
        }
        else
        {
            GoblinHealth.SetActive(false);
            enemy.active = false;
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

            if (collision.gameObject.name == "Sorcerer")
            {
                CanMove = false;
                DialogueManager.Instance.StartDialogue(4);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("BossArrow"))
        {
            heroHealth--;
            health.text = heroHealth.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void SwapWeapon()
    {
        if (onBasicArrow)
        {
            onBasicArrow = false;
        }
        else
        {
            onBasicArrow = true;
        }
    }

    private void Fire(float rotation)
    {
        GameObject bullet = Instantiate(onBasicArrow ? basicArrowPrefab : magicArrowPrefab, transform.position, Quaternion.identity);
        bullet.transform.Rotate(0f, 0f, rotation);
    }
}
