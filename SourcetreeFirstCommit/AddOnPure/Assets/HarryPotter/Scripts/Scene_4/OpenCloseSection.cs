using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSection : MonoBehaviour
{

    private AudioSource audioplay;
    public AudioClip enter;
    public AudioClip exit;

    public static bool isInOpenCloseSection = false;

    // Start is called before the first frame update
    void Start()
    {
        audioplay = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "MainCamera")
        {
            isInOpenCloseSection = true;

            audioplay.clip = enter;
            audioplay.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "MainCamera")
        {
            isInOpenCloseSection = false;

            audioplay.clip = exit;
            audioplay.Play();
        }
    }

}
