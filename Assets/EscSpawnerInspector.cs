using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(mcSpawner))]
public class EscSpawnerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var spawner = (mcSpawner) target;
        if (GUILayout.Button("Update"))
        {
            spawner.UpdateData();
        }
    }
}
