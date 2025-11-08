using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundPlayer : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource bellSource;
    public AudioClip blackNoise;
    public AudioClip bell;

    float bellTimer = 0;
    float ambientTimer = 0;
    int playNext;

    // Start is called before the first frame update
    void Start()
    {
        //ambientSource = ambientSource.GetComponent<AudioSource>();
        //bellSource = bellSource.GetComponent<AudioSource>();
        playNext = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {

        bellTimer += Time.deltaTime;
        ambientTimer += Time.deltaTime;

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
    }
}
