using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderScript : MonoBehaviour {
    [SerializeField]
    private Layer[] layers;

    public void GenerateMap() {
        Clear(); // Clear the map at build

        for (int i = 0; i < layers.Length; i++) {
            foreach (MapElement mapElement in layers[i].Prefabs) { // Run through each map element inside the configuration container/layer in the Unity inspector
                layers[i].MapElements.Add(mapElement.Color.ToString(), mapElement); // Take each tile and add them to a dictionary (ConfigurationContainer.cs)
            }
        }

        int height = layers[0].MapData.height;
        int width = layers[0].MapData.width;

        for (int i = 0; i < layers.Length; i++) {
            for (int x = 0; x < width; x++) { // run through each pixel on the tilemap
                for (int y = 0; y < height; y++) {
                    Color32 c = layers[i].MapData.GetPixel(x, y); // Determine if need to place a pixel on the tilemap based on the image "map data"
                    MapElement mapElement;
                    layers[i].MapElements.TryGetValue(c.ToString(), out mapElement); // get the colour value from the dictionary, turn the colour into a string and map it to the mapElement

                    if (mapElement != null) {
                        int index = 0;

                        if (mapElement.GameObjects.Length > 1) {
                            // Create random tile
                        }

                        GameObject go = Instantiate(mapElement.GameObjects[index], layers[i].Parent);
                        go.transform.position = new Vector3(mapElement.MeshRenderer.bounds.size.x * x, 0, mapElement.MeshRenderer.bounds.size.x * y);
                    }
                }
            }
        }
    }

    public void Clear() {
        for (int i = 0; i < layers.Length; i++) {
            while (layers[i].Parent.childCount > 0) {
                for (int j = 0; j < layers[i].Parent.childCount; j++) {
                    DestroyImmediate(layers[i].Parent.GetChild(j).gameObject);
                }
            }
        }

        // Clear dictionary
        for (int i = 0; i < layers.Length; i++) {
            layers[i].MapElements.Clear();
        }
    }
}