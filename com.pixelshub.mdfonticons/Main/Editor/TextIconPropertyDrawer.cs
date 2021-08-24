using UnityEngine;
using UnityEditor;

namespace Google.MaterialDesign.Icons
{
    [CustomPropertyDrawer(typeof(MDTextIcon)), CanEditMultipleObjects]
    class TextIconDrawer : PropertyDrawer
    {
        private static readonly Color darkColor = new Color(0.196f, 0.196f, 0.196f);
        private static readonly Color lightColor = new Color(0.804f, 0.804f, 0.804f);

        private GUIStyle iconStyle = null;        

        public void InitializeStyle()
        {
            iconStyle = new GUIStyle();
            iconStyle.fontSize = 56;
            iconStyle.alignment = TextAnchor.MiddleCenter;
            iconStyle.normal.textColor = iconStyle.active.textColor = iconStyle.focused.textColor = iconStyle.hover.textColor = EditorGUIUtility.isProSkin ? lightColor : darkColor;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 64 + 10+24;//base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (iconStyle == null) InitializeStyle();

            SerializedProperty iconConfig = property.FindPropertyRelative("config");
            SerializedProperty style = property.FindPropertyRelative("style");
            SerializedProperty text = property.FindPropertyRelative("text");

            if (iconConfig.objectReferenceValue == null)
            {
                string[] guid = AssetDatabase.FindAssets("t:MaterialIconConfig");
                if (guid.Length == 0) return;
                else
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(guid[0]);
                    iconConfig.objectReferenceValue = AssetDatabase.LoadAssetAtPath<MaterialIconConfig>(assetPath);
                }
                iconConfig.serializedObject.ApplyModifiedProperties();
            }

            if (iconConfig.objectReferenceValue == null)
            {
                EditorGUILayout.HelpBox("Could not find font styles config asset.", MessageType.Error);
                return;
            }

            MaterialIconConfig.FontStyle fontStyle = ((MaterialIconConfig)iconConfig.objectReferenceValue).FontStyles[style.intValue];

            iconStyle.font = fontStyle.Font;
            this.DoIconStylesDropdown(new Rect(position.x, position.y, position.width, 24), style, ((MaterialIconConfig)iconConfig.objectReferenceValue));

            this.DoIconControl(new Rect(position.x, position.y + 34, 64, 64), text, () =>
            {
                MaterialIconSelectionWindow.Init(fontStyle, text.stringValue, (selected) =>
                {
                    text.stringValue = selected;
                    property.serializedObject.ApplyModifiedProperties();
                });
            });

            property.serializedObject.ApplyModifiedProperties();
        }

        private string TextToUnicode(string text)
        {
            if (text == string.Empty) return "";
            return System.Convert.ToString(char.ConvertToUtf32(text, 0), 16);
        }

        private string UnicodeToText(string unicode)
        {
            return char.ConvertFromUtf32(System.Convert.ToInt32(unicode, 16));
        }

        private void DoIconControl(Rect position, SerializedProperty text, System.Action callback)
        {
            GUIContent guiContent = new GUIContent("Icon");
            GUIContent mixedContent = new GUIContent("\u2014", "Mixed Values");
            EditorGUI.BeginProperty(position, guiContent, text);
            Rect rect = EditorGUI.PrefixLabel(position, guiContent);
            rect.width = rect.height;
            if (GUI.Button(rect, text.hasMultipleDifferentValues ? mixedContent : new GUIContent(string.Empty, TextToUnicode(text.stringValue))))
                callback.Invoke();
            GUI.Label(rect, text.hasMultipleDifferentValues ? string.Empty : text.stringValue, iconStyle);
            EditorGUI.EndProperty();
        }

        private void DoIconStylesDropdown(Rect rect, SerializedProperty style, MaterialIconConfig config)
        {
            if (!config) EditorGUILayout.HelpBox("Could not find font styles config asset.", MessageType.Error);
            else
            {

                string[] options = new string[config.FontStyles.Length];
                for (int i = 0; i < options.Length; i++)
                {
                    options[i] = config.FontStyles[i].StyleName;
                }
                int preVal = style.intValue;
                style.intValue = EditorGUI.Popup(rect, "Icon Style", style.intValue, options);

                if(style.intValue != preVal)
                {
                    MaterialIconSelectionWindow window = EditorWindow.GetWindow<MaterialIconSelectionWindow>(true);
                    if(window != null)
                    {
                        window.Close();
                    }
                }
            }

        }


    }
}
