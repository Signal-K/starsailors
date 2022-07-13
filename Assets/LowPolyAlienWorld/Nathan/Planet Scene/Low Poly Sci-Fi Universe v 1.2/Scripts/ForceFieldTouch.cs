using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ForceFieldTouch : MonoBehaviour
{

   public AudioClip theSound;
 
   new AudioSource audio;
   
    
   
    // Use this for initialization
    void Start()
    {
        
      
        audio = GetComponent<AudioSource>();
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
           audio.PlayOneShot(theSound, 1.0F);
        }
    }

    

    
}
