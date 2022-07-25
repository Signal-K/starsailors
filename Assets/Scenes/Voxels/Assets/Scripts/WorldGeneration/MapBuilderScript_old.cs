/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderScript : MonoBehaviour {
    [SerializeField]
    private Layer[] layers;

    public void GenerateMap() {
        Clear();

        // Loop through al the configuration containers (map layers)
        for (int i = 0; i < layers.Length; i++) {
            foreach (MapElement mapElement in layers[i].Prefabs) {
                layers[i].MapElements.Add(mapElement.Color.ToString(), mapElement);
            }
        }

        int height = layers[0].MapData.height;
        int width = layers[0].MapData.width;

        for (int i = 0; i < layers.Length; i++) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Color32 c = layers[i].MapData.GetPixel(x, y);
                    MapElement mapElement;
                    layers[i].MapElements.TryGetValue(c.ToString(), out mapElement);

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

    public void Clear() { // clear/remove the map if we don't want the current build/iteration
        for (int i = 0; i < layers.Length; i++) {
            while (layers[i].Parent.childCount > 0) {
                for (int j = 0; j < layers[i].Parent.childCount; j++) {
                    DestroyImmediate(layers[i].Parent.GetChild(j).gameObject);
                }
            }
        }

        for (int i = 0; i < layers.Length; i++) {
            layers[i].MapElements.Clear();
        }
    }
}
*/