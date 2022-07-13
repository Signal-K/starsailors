using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {

    public bool night;
    private float dayDuration = 5f;
    // private float _timer = 0f;
    public Material material;
  

    // Use this for initialization
    void Start () {
        night = false;
        StartCoroutine("delayDay");
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    IEnumerator delayDay()
    {

        Invoke("TurnOff", 1);//turn off emissions it is DAY
        

        yield return new WaitForSeconds(dayDuration);    //Wait seconds

        Invoke("TurnOn", 1); //turn on emissions it is NIGHT

    }

    public void TurnOn()
    {
        night = true;
        Debug.Log("IT IS NOW NIGHT!");
        material.EnableKeyword("_EMISSION"); //turn on emissions

    }

    public void TurnOff()
    {
        night = false;
        Debug.Log("IT IS NOW DAY!");
        material.DisableKeyword("_EMISSION"); //turn off emissions

    }
}
