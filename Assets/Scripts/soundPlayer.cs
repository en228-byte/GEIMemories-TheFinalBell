using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource bellSource;
    public AudioSource step;
    public AudioClip blackNoise;
    public AudioClip bell;



    float bellTimer = 0;
    int playNext;

    // Start is called before the first frame update
    void Start()
    {
        //ambientSource = ambientSource.GetComponent<AudioSource>();
        //bellSource = bellSource.GetComponent<AudioSource>();
        playNext = Random.Range(1, 10);
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

        /*
        if (ambientTimer >= playNext && !ambientSource.isPlaying)
        {
            float startAt = Random.Range(0, ambientSource.clip.length - 1);
            ambientSource.volume = Random.Range(0.2f, 1.0f);
            ambientSource.time = (int)startAt;
            ambientSource.Play();
            playNext = Random.Range(1, 40);
            ambientTimer = 0;
        }*/
        if (Input.GetKey(KeyCode.D))
        {
            if (!step.isPlaying)
            {
                step.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (step.isPlaying)
            {
                step.Stop();
            }
        }
        //move backwards (right to left)
        if (Input.GetKey(KeyCode.A))
        {
            if (!step.isPlaying)
            {
                step.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (step.isPlaying)
            {
                step.Stop();
            }
        }
        //move up (down to up)
        if (Input.GetKey(KeyCode.W))
        {
            if (!step.isPlaying)
            {
                step.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            if (step.isPlaying)
            {
                step.Stop();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!step.isPlaying)
            {
                step.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (step.isPlaying)
            {
                step.Stop();
            }
        }
    }
}
