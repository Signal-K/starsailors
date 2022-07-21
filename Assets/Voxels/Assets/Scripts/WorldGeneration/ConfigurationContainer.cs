using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConfigurationContainer {
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
}
