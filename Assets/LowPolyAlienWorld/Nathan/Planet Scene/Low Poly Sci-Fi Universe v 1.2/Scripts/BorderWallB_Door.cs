using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BorderWallB_Door : MonoBehaviour
{

   public AudioClip doorSound;
 //AudioSource audio;
   new AudioSource audio;
   public GameObject GO_Door;

    bool doorOpen;
   
    // Use this for initialization
    void Start()
    {
        doorOpen = false;
       
        audio = GetComponent<AudioSource>();
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorOpen = true;
            GO_Door.GetComponent<Renderer>().enabled = false;
      audio.PlayOneShot(doorSound, 1.0F);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            GO_Door.GetComponent<Renderer>().enabled = true;
            audio.PlayOneShot(doorSound, 1.0F);
        }
    }

    
}
