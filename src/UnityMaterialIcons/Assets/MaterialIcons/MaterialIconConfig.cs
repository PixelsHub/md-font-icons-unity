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
        [SerializeField] Object tmp_Font;

        public string StyleName {  get {  return styleName; } }
        public Font Font {  get { return baseFont; } }
        public Object TMP_Font {  get {  return tmp_Font; }  }

    }


    [SerializeField] FontStyle[] fontStyles;
    [SerializeField] TextAsset codepoints;

    public FontStyle[] FontStyles {  get {  return fontStyles; } }
    public TextAsset Codepoints {  get {  return codepoints; } }
}
