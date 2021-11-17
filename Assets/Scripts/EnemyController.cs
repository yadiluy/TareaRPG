using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public bool active = false;
    public GameObject arrow;
    private float speed = 5f;
    private float max = 8f;
    private float min = -8f;
    private Vector3 direction = Vector3.up;
    private float time = 0f;

    public Text health;
    private float enemyHealth = 5f;

    private void Update()
    {
        if (active)
        {
            transform.position += direction * speed * Time.deltaTime;
            if (Time.time - time > 2f)
            {
                time = Time.time;
                float random = Random.Range(0.0f, 10.0f);
                if (random < 1f)
                {
                    direction *= -1;
                }
                if (random > 3f)
                {
                    Fire();
                }
            }
            if (transform.position.y >= 8f || transform.position.y <= -8f)
            {
                direction *= -1;
            }
        }
        if (enemyHealth <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    private void Fire()
    {
        Instantiate(arrow, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("BasicArrow") || collision.transform.CompareTag("MagicArrow"))
        {
            enemyHealth--;
            health.text = enemyHealth.ToString();
            Destroy(collision.gameObject);
        }
    }
}
