using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserCreeper : MonoBehaviour
{
    [Header("Follow")]
    public Transform target;
    public float baseSpeed = 4.5f;
    public float xFollowLerp = 4f;
    public float gapBehind = 1.2f;

    [Header("Catch-up")]
    public float bonusSpeed = 0f;
    public float bonusDecay = 0.3f;
    public float bonusMax = 2.0f;

    void LateUpdate()
    {
        if (!target) return;

        float desiredX = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * xFollowLerp);
        float desiredY = target.position.y - gapBehind;
        Vector3 desired = new Vector3(desiredX, desiredY, transform.position.z);

        float currentSpeed = baseSpeed + bonusSpeed;
        transform.position = Vector3.MoveTowards(transform.position, desired, currentSpeed * Time.deltaTime);

        bonusSpeed = Mathf.MoveTowards(bonusSpeed, 0f, bonusDecay * Time.deltaTime);
    }

    public void AddAggro(float amount)
    {
        bonusSpeed = Mathf.Clamp(bonusSpeed + amount, 0f, bonusMax);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerRunner>() != null)
            FindObjectOfType<GameManager>()?.Lose();
    }
}