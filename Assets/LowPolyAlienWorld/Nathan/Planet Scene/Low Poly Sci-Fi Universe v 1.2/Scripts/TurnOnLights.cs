using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {

    public Material material;
    public GameObject AutoIntensity;

    void Awake()
    {

       // material.DisableKeyword("_EMISSION"); //reset to day closed emissions
    }

    // Use this for initialization
    void Start () {
      //  Invoke("TurnOn", 10);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
     //   if (AutoIntensity.GetComponent<AutoIntensity>().night == true)
     //   {
            Invoke("TurnOn", 1);
     //   }
     //   else if (AutoIntensity.GetComponent<AutoIntensity>().night == false)
      //  {
            Invoke("TurnOff", 1);
      //  }

    }

    public void TurnOn()
    {
        material.EnableKeyword("_EMISSION"); //turn on emissions

    }

    public void TurnOff()
    {
        material.DisableKeyword("_EMISSION"); //turn off emissions

    }
}
