using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChase : MonoBehaviour
{
    public float speed = 2f;
    Transform player;

    void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (!player) return;
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
