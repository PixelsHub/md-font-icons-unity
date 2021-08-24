
using UnityEngine;
using UnityEditor;
using System.Reflection;
using TMPro;


namespace Google.MaterialDesign.Icons
{

    [CustomEditor(typeof(MaterialIconTMP), true), CanEditMultipleObjects]
    public class MaterialIconTMPEditor : Editor
    {
        private SerializedProperty spColor;
        private SerializedProperty icon;
        private SerializedProperty spRaycastTarget;

        protected void OnEnable()
        {
            spColor = serializedObject.FindProperty("m_fontColor");
            spRaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            icon = serializedObject.FindProperty("icon");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(icon);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(spColor);
            EditorGUILayout.PropertyField(spRaycastTarget);

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

    }

}
