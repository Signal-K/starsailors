using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapElement {
    [SerializeField]
    private string name;
    [SerializeField]
    private GameObject[] gameObjects;
    [SerializeField]
    private Color32 color;
    [SerializeField]
    private MeshRenderer meshRenderer; // determine the size of the tile so we can place the next one

    public GameObject[] GameObjects { get => gameObjects; set => gameObjects = value; }
    public Color32 Color { get => color; set => color = value; }
    public MeshRenderer MeshRenderer { get => meshRenderer; set => meshRenderer = value; }
}
