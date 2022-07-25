using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderScript : MonoBehaviour {
    [SerializeField]
    private ConfigurationContainer[] configurationContainers;

    public void GenerateMap() {
        for (int i = 0; i < configurationContainers.Length; i++) {
            foreach (MapElement mapElement in configurationContainers[i].Prefabs) { // Run through each map element inside the configuration container/layer in the Unity inspector
                configurationContainers[i].MapElements.Add(mapElement.Color.ToString(), mapElement); // Take each tile and add them to a dictionary (ConfigurationContainer.cs)
            }
        }
    }
}