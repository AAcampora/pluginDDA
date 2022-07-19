using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DDAManager))]
public class DDAInspector : EditorWindow
{
    string name = " ";
    DDAManager targetManager;
    DataCollector targetCollector;

    [MenuItem("Window/Hamlet DDA")]

    public static void ShowWindow()
    {
        DDAInspector window = EditorWindow.GetWindow<DDAInspector>();
        window.Show();
    }
    void OnGUI()
    {
        GUILayout.Label("Manager Settings", EditorStyles.boldLabel);
        targetManager = (DDAManager)EditorGUILayout.ObjectField(targetManager, typeof(DDAManager), true);

        GUILayout.Label("Observers Settings", EditorStyles.boldLabel);
        name = EditorGUILayout.TextField("name of Observer", name);
        targetCollector = (DataCollector)EditorGUILayout.ObjectField(targetCollector, typeof(DataCollector), true);


        if (GUILayout.Button("Insert new Observer Value"))
        {
            //targetManager.InsertSurveryor(name, targetCollector);
        }
    }
}

