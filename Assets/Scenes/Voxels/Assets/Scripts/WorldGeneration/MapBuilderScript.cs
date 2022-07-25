using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderScript : MonoBehaviour {
    [SerializeField]
    private ConfigurationContainer[] configurationContainers;

    public void GenerateMap() {
        // Loop through al the configuration containers (map layers)
        for (int i = 0; i < configurationContainers.Length; i++) {
            foreach (MapElement mapElement in configurationContainers[i].Prefabs) {
                configurationContainers[i].MapElements.Add(mapElement.Color.ToString(), mapElement);
            }
        }

        int height = configurationContainers[0].MapData.height;
        int width = configurationContainers[0].MapData.width;

        for (int i = 0; i < configurationContainers.Length; i++) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Color32 c = configurationContainers[i].MapData.GetPixel(x, y);
                    MapElement mapElement;
                    configurationContainers[i].MapElements.TryGetValue(c.ToString(), out mapElement);

                    if (mapElement != null) {
                        int index = 0;

                        if (mapElement.GameObjects.Length > 1) {
                            // Create random tile
                        }

                        GameObject go = Instantiate(mapElement.GameObjects[index], configurationContainers[i].Parent);
                    }
                } 
            }
        }
    }

    public void Clear() { // clear/remove the map if we don't want the current build/iteration

    }
}
