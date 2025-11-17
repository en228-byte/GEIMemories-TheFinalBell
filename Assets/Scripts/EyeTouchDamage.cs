using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTouchDamage : MonoBehaviour
{
    public int damage = 1;
    public float hitCooldown = 0.5f;
    float nextHitTime = 0f;

    void TryHit(GameObject other)
    {
        if (Time.time < nextHitTime) return;
        if (!other.CompareTag("Player")) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph)
        {
            ph.TakeHit(damage);
            nextHitTime = Time.time + hitCooldown;
        }
    }

    // trigger setup
    void OnTriggerEnter2D(Collider2D other) => TryHit(other.gameObject);
    void OnTriggerStay2D(Collider2D other)  => TryHit(other.gameObject);

    // collision setup
    void OnCollisionEnter2D(Collision2D col) => TryHit(col.collider.gameObject);
    void OnCollisionStay2D(Collision2D col)  => TryHit(col.collider.gameObject);
}