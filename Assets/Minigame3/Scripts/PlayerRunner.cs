using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private CameraShake camShake;
    [Header("Move")]
    public float forwardSpeed = 6f;
    public float horizontalSpeed = 6f;
    public float laneClamp = 3.2f;

    [Header("Hit Slowdown")]
    public float minForwardSpeed = 3f;
    public float onHitSlowdown = 2f;
    public float recoverPerSecond = 1.5f;
    private float baseForwardSpeed;

    void Start()
    {
        baseForwardSpeed = forwardSpeed;
    }

    void Update()
    {
        // auto move up
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime, Space.World);

        // left, right
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            transform.Translate(Vector3.right * x * horizontalSpeed * Time.deltaTime, Space.World);
            var p = transform.position;
            p.x = Mathf.Clamp(p.x, -laneClamp, laneClamp);
            transform.position = p;
        }

        // recovery back to base speed
        forwardSpeed = Mathf.MoveTowards(forwardSpeed, baseForwardSpeed, recoverPerSecond * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // win
        if (other.CompareTag("Finish"))
        {
            FindObjectOfType<GameManager>()?.Win();
            return;
        }

        // slowdown
        if (other.CompareTag("Obstacle"))
        {
            forwardSpeed = Mathf.Max(minForwardSpeed, forwardSpeed - onHitSlowdown);

            // camera shake
            if (camShake) StartCoroutine(camShake.Shake(0.2f, 0.15f));

            GetComponent<SpriteFlash>()?.Trigger();
            
            // chaser surge
            var chaser = FindObjectOfType<ChaserCreeper>();
            if (chaser) chaser.AddAggro(0.8f);

            Destroy(other.gameObject);
        }   
    }
}