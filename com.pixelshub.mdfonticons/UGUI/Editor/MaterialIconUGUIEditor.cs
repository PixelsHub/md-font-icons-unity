
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace Google.MaterialDesign.Icons
{

    [CustomEditor(typeof(MaterialIconUGUI), true), CanEditMultipleObjects]
    public class MaterialIconUGUIEditor : UnityEditor.UI.TextEditor
    {

        private SerializedProperty spIcon;
        private SerializedProperty spColor;
        private SerializedProperty spRaycastTarget;
        private SerializedProperty spAlignment;

        protected override void OnEnable()
        {
            base.OnEnable();
            MaterialIconUGUI icon = target as MaterialIconUGUI;

            if (string.IsNullOrEmpty(icon.text))
            {
                icon.Init();
            }


            spIcon = serializedObject.FindProperty("icon");
            spColor = serializedObject.FindProperty("m_Color");
            spRaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            spAlignment = serializedObject.FindProperty("m_FontData.m_Alignment");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();


            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(spIcon);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(spColor);
            EditorGUILayout.PropertyField(spRaycastTarget);

            EditorGUILayout.Space();

            Rect alignmentRect = GUILayoutUtility.GetRect(EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
            DoTextAlignmentControl(alignmentRect, spAlignment);

            serializedObject.ApplyModifiedProperties();
        }

        /// <summary> Reflection for the private synonymous method from the FontDataDrawer class. </summary>
        private static readonly MethodInfo DoHorizontalAlignmentControl = typeof(UnityEditor.UI.FontDataDrawer).GetMethod("DoHorizontalAligmentControl", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary> Reflection for the private synonymous method from the FontDataDrawer class. </summary>
        private static readonly MethodInfo DoVerticalAlignmentControl = typeof(UnityEditor.UI.FontDataDrawer).GetMethod("DoVerticalAligmentControl", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary> Workaround for the non-static private synonymous method from the FontDataDrawer class. </summary>
        private static void DoTextAlignmentControl(Rect position, SerializedProperty alignment)
        {
            try
            {
                GUIContent guiContent = new GUIContent("Alignment");
                EditorGUIUtility.SetIconSize(new Vector2(15f, 15f));
                EditorGUI.BeginProperty(position, guiContent, alignment);
                Rect rect = EditorGUI.PrefixLabel(position, guiContent);
                float size1 = 60f;
                float size2 = Mathf.Clamp(rect.width - size1 * 2f, 2f, 10f);
                Rect position2 = new Rect(rect.x, rect.y, size1, rect.height);
                Rect position3 = new Rect(position2.xMax + size2, rect.y, size1, rect.height);
                DoHorizontalAlignmentControl.Invoke(null, new object[] { position2, alignment });
                DoVerticalAlignmentControl.Invoke(null, new object[] { position3, alignment });
                EditorGUI.EndProperty();
                EditorGUIUtility.SetIconSize(Vector2.zero);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

    }

}
