using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTrigger : MonoBehaviour
{
    protected GameObject mainCamera;
    public AudioSource source;
   
    private bool isPlayed;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
        isPlayed = false;
    }

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        // if (!isPlayed)
        //  {
        if (other.gameObject.Equals(mainCamera))
        {
            source.Play();
            isPlayed = true;
            Debug.Log("sound on");
        }
        //}
    }
   public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(mainCamera))
        {

            source.Stop();
            Debug.Log("sound off");
        }
        
    }
    //private void Update()
    //{
    //    print("check");
    //}
}
