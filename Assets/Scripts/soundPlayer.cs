using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource bellSource;
    public AudioSource stepSource;

    public AudioClip ambient1;
    public AudioClip ambient2;
    public AudioClip ambient3;
    public AudioClip ambient4;
    public AudioClip ambient5;

    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    public AudioClip step4;
    public AudioClip step5;

    

    public AudioClip bell;



    float bellTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        ambientSource.clip = ambient1;
        stepSource.clip = step1;
        ambientSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
            bellTimer += Time.deltaTime;
        //ambientTimer += Time.deltaTime;

        if (bellTimer >= 120 && !bellSource.isPlaying)
        {
            bellSource.Play();
            bellTimer = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!stepSource.isPlaying)
            {
                stepSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (stepSource.isPlaying)
            {
                stepSource.Stop();
            }
        }
        //move backwards (right to left)
        if (Input.GetKey(KeyCode.A))
        {
            if (!stepSource.isPlaying)
            {
                stepSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (stepSource.isPlaying)
            {
                stepSource.Stop();
            }
        }
        //move up (down to up)
        if (Input.GetKey(KeyCode.W))
        {
            if (!stepSource.isPlaying)
            {
                stepSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            if (stepSource.isPlaying)
            {
                stepSource.Stop();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!stepSource.isPlaying)
            {
                stepSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (stepSource.isPlaying)
            {
                stepSource.Stop();
            }
        }
        //change clips of step and ambient based on decay
        if (MemoryTracker.badMemoriesFound > 3)
        {
            ambientSource.clip = ambient5;
            ambientSource.volume = 0.5f;
            ambientSource.pitch = 0.5f;

            stepSource.clip = step5;
            stepSource.pitch = 1.65f;

        } 
        else if (MemoryTracker.badMemoriesFound == 3)
        {
            ambientSource.clip = ambient4;
            ambientSource.volume = 0.5f;
            ambientSource.pitch = 0.5f;

            stepSource.clip = step4;
            stepSource.pitch = 1.5f;;

        } 
        else if (MemoryTracker.badMemoriesFound == 2)
        {
            ambientSource.clip = ambient3;
            ambientSource.volume = 1f;
            ambientSource.pitch = -0.25f;

            stepSource.clip = step3;
            stepSource.pitch = 1.0f;

        } 
        else if (MemoryTracker.badMemoriesFound == 1)
        {
            ambientSource.clip = ambient2;
            ambientSource.volume = 0.25f;
            ambientSource.pitch = 1f;

            stepSource.clip = step2;
            stepSource.pitch = 1.25f;

        } else
        {
            ambientSource.clip = ambient1;
            ambientSource.volume = 1f;
            ambientSource.pitch = 0.75f;

            stepSource.clip = step1;
            stepSource.pitch = 1f;

        }
        if (!ambientSource.isPlaying)
        {
            ambientSource.Play();
        }
    }
}
