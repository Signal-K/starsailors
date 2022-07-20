using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapBuilderScript))]
public class MapBuilderEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        MapBuilderScript myScript = (MapBuilderScript)target; // target -> update we are targeting

        if (GUILayout.Button("Build map")) {
            myScript.GenerateMap();
        }
        if (GUILayout.Button("Clear")) {
            myScript.Clear();
        }
    }
}
