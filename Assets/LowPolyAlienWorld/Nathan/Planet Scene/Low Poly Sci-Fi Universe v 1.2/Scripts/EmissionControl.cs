using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{

    public Material material;
    public bool night;

    void Awake()
    {
       
        material.DisableKeyword("_EMISSION");
    }

    void Start()
    {
          
            StartCoroutine(EnableAfterTime());
       
    }

   

    IEnumerator EnableAfterTime()
    {
      
            yield return new WaitForSeconds(100);
            material.EnableKeyword("_EMISSION");
            
        
    }

   
}