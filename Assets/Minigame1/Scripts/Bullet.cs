using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    GooMonsterController enemy = collision.GetComponent<GooMonsterController>();
    if (enemy != null)
    {
        enemy.TakeDamage(1); // each bullet does 1 damage
        Destroy(gameObject); // bullet disappears on hit
    }
    }

}