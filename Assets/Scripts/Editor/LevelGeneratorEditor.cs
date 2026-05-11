using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))] 
public class LevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generuj"))
        {
            var generator = (LevelGenerator)target;
            generator.GenerateLabirynth();
        }
        if (GUILayout.Button("Wyczyœæ"))
        {
            var generator = (LevelGenerator)target;
            generator.Clear();
        }
    }
}
