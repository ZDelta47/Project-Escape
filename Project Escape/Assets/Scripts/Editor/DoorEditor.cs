using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DoorController))]
public class DoorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DoorController doorController = (DoorController)target;

        if(GUILayout.Button("Open / Close"))
        {
            doorController.ActivateDoor();
        }
    }
}
