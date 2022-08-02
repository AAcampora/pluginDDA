using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System;


[CustomEditor(typeof(DDAManager))]
public class DDAInspector : EditorWindow
{
    string name = " ";
    DDAManager targetManager; 
    GameObject targetCollector;
    public int index = 0;
    public DataCollector objectToGrab;
    float item;

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
        objectToGrab = (DataCollector)EditorGUILayout.ObjectField(objectToGrab, typeof(DataCollector), true);
        List<string> options = new List<string>();
        if (objectToGrab)
        {
            var fields = objectToGrab.GetComponent<DataCollector>().GetType().GetFields();
            foreach (var field in fields)
            {
                options.Add(field.Name);
            }
            index = EditorGUILayout.Popup(index, options.ToArray());

            var selectedItem = fields[index].GetValue(objectToGrab.GetComponent<DataCollector>());
            Debug.Log(selectedItem);
        }
        



        //index = EditorGUILayout.Popup(index, properties);

        if (GUILayout.Button("Insert new Observer Value"))
        {
            //targetManager.InsertSurveryor(name, targetCollector);
        }
    }
}

