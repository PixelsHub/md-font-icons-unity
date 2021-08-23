using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "MaterialIconConfig", menuName = "Material Design Font Icon/Create config")]
public class MaterialIconConfig : ScriptableObject
{
    [System.Serializable]
    public struct FontStyle
    {
        [SerializeField] string styleName;
        [SerializeField] Font baseFont;
        [SerializeField] Object tmpFont;
        [SerializeField] TextAsset codepoints;
        [SerializeField] public bool copyHexCodesToClipboard;
        public string StyleName { get { return styleName; } }
        public Font Font { get { return baseFont; } }
        public Object TMP_Font { get { return tmpFont; } }
        public string Codepoints { get { return codepoints.text; } }
    }


    [SerializeField] FontStyle[] fontStyles;

    public FontStyle[] FontStyles { get { return fontStyles; } }

    void OnValidate()
    {
        for (int i = 0; i < fontStyles.Length; i++)
        {
            if (fontStyles[i].copyHexCodesToClipboard)
            {
                string hex = "";
                foreach (string codepoint in fontStyles[i].Codepoints.Split('\n'))
                {
                    if (codepoint.Trim().Length == 0) continue;
                    string[] data = codepoint.Split(' ');
                    
                    if (hex != "") hex += ",";
                    hex += data[1];
                }

                GUIUtility.systemCopyBuffer = hex;
                fontStyles[i].copyHexCodesToClipboard = false;
            }
        }
    }
}
