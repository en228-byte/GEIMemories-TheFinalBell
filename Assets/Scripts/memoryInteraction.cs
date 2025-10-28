using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryInteraction : MonoBehaviour
{
    public string nextScene;
    public GameObject memory;
    GameObject goodMemory1;
    GameObject goodMemory2;
    GameObject goodMemory3;
    GameObject badMemory1;
    GameObject badMemory2;

    private void Start()
    {
        goodMemory1 = Instantiate(memory);
        goodMemory1.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);

        goodMemory2 = Instantiate(memory);
        goodMemory2.transform.position = new Vector3(6.0f, 6.0f, 0.0f);
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneChanging sceneChanger = new SceneChanging();
            sceneChanger.ChangeScene(nextScene);
            Destroy(collision.gameObject);
        }
    }
}
