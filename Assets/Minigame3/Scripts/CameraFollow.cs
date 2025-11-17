using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target; // for player
    public float yOffset = 2.5f;

    void LateUpdate() {
        if (!target) return;
        transform.position = new Vector3(0f, target.position.y + yOffset, -10f);
    }
}