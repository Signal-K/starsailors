using UnityEngine;
using System.Collections;

public class EmissionRndIntensity : MonoBehaviour
{

    public float minWaitTime;
    public float maxWaitTime;

    Material material;
    public Color color;
    [HideInInspector]
    [SerializeField]
    new Renderer renderer;

    void Reset()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    // Use this for initialization
    void Start()
    {

        StartCoroutine(Flashing());
        material = renderer.sharedMaterial;

        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
           // renderer.enabled = !renderer.enabled;
            material.SetColor("_EmissionColor", Color.black);
        }
    }

    // Update is called once per frame
    void Update()
    {


        //float emission = Mathf.PingPong(Time.time, 1f);
        float emission =14f;
        Color baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        material.SetColor("_EmissionColor", finalColor);
        RendererExtensions.UpdateGIMaterials(renderer);
        DynamicGI.UpdateEnvironment();
    }
}
