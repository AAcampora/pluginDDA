using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DDAManager))]
public class DDAInspector : EditorWindow
{
    string name = " ";
    DDAManager targetManager;
    GameObject targetCollector;
    public int index = 0;

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
        targetCollector = (GameObject)EditorGUILayout.ObjectField(targetCollector, typeof(GameObject), true);

        var properties = targetCollector.GetComponent<DataCollector>().GetType().GetFields();
        for (int i = 0; i < properties.Length; i++)
        {
            Debug.Log(properties[i].ToString());
        }
        //index = EditorGUILayout.Popup(index, properties);

        if (GUILayout.Button("Insert new Observer Value"))
        {
            //targetManager.InsertSurveryor(name, targetCollector);
        }
    }
}

