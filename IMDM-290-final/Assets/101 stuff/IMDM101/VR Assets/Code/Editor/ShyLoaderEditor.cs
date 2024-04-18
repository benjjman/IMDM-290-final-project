using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShyLoader), true)]
public class ShyLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ShyLoader sl = target as ShyLoader;

        SerializedObject s = new SerializedObject(sl.Serial());

        SerializedProperty spShyImage = s.FindProperty("shyImage");
        SerializedProperty spShrinkImage = s.FindProperty("shrinkImage");
        SerializedProperty spWaitTime = s.FindProperty("waitTime");
        SerializedProperty spShrinkTime = s.FindProperty("shrinkTime");
        SerializedProperty spPlayAudio = s.FindProperty("playAudio");
        SerializedProperty spAudioClip = s.FindProperty("audioClip");

        serializedObject.Update();
        s.Update();

        EditorGUILayout.PropertyField(spShyImage, new GUIContent("ShyImage"));
        EditorGUILayout.PropertyField(spShrinkImage, new GUIContent("ShrinkImage"));
        EditorGUILayout.PropertyField(spWaitTime, new GUIContent("waitTime"));
        EditorGUILayout.PropertyField(spShrinkTime, new GUIContent("shrinkTime"));
        EditorGUILayout.PropertyField(spPlayAudio, new GUIContent("playAudio"));
        EditorGUILayout.PropertyField(spAudioClip, new GUIContent("audioClip"));

        s.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();

        sl.Serial().Load();
    }
}