using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    // +1 = right, -1 = left
    [HideInInspector] public float direction = 1f;
    public float lifeTime = 2f;
    public int damage = 1;
    float lifeTimer = 0f;

    void Update()
    {
        // bullet movement
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EyeController enemyHealth = collision.GetComponent<EyeController>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}