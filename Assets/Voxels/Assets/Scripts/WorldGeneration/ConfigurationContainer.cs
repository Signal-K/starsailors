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
}
