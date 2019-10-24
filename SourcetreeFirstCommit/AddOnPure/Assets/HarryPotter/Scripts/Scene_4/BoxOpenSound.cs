using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenSound : MonoBehaviour
{
    public AudioClip harry;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (RaycastFlowerBlossom.isPlayingBoxOpenSound == true)
        //{
        //    audio.clip = harry;
        //    audio.Play();
        //}
    }
}
