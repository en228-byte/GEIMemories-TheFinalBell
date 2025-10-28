using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if door is hit by anything (it could only be door or something has gone wrong)
    //when hit opens prefab of next area
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
        }
    }
}
