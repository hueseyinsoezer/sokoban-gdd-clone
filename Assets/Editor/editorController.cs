using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(mapController))]

public class editorController : Editor
{
    public int a;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        mapController map = (mapController)target;
        if (GUILayout.Button("create_a_map"))
        {
            map.createMap();
        }
        if (GUILayout.Button("delete_map"))
        {
            map.deleteMap();
        }
        if (GUILayout.Button("save_steps_from_gameobject"))
        {
            map.SaveStepsFromGameObject(a);
        }
    }

}
