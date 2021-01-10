using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(McSpawner))]
public class EscSpawnerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var spawner = (McSpawner) target;
        GUI.enabled = Application.isPlaying;
        if (GUILayout.Button("Update"))
        {
            spawner.UpdateData();
        }
        GUI.enabled = true;

    }
}
