using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public GameObject instructions;
    bool IsOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeInstructionDisplay();
    }

    public void changeInstructionDisplay()
    {
        instructions.SetActive(IsOpen);
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsOpen = !IsOpen;
        }
    }
}
