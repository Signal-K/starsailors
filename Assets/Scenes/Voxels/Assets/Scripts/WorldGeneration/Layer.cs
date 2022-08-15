using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Layer {
    [SerializeField]
    private string name;
    [SerializeField]
    private Transform parent; // game object that all functions are instantiated to
    [SerializeField]
    private MapElement[] prefabs;
    [SerializeField]
    private Texture2D mapData;

    // Dictionary -> all map elements
    public Dictionary<string, MapElement > MapElements { get; set; } = new Dictionary<string, MapElement>();

    public MapElement[] Prefabs { get => prefabs; private set => prefabs = value; }
    public Transform Parent { get => parent; private set => parent = value; }
    public Texture2D MapData { get => mapData; private set => mapData = value; }

    // Color codes: alpha 255, dirt: (734300), sand: (F6FF93), water: (0EA1FF)
}
