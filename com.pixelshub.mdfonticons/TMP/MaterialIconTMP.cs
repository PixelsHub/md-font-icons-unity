
using UnityEngine;
using TMPro;

namespace Google.MaterialDesign.Icons
{

    public class MaterialIconTMP : TMPro.TextMeshProUGUI
    {
        [SerializeField] MDTextIcon icon;

        protected override void Start()
        {
            base.Start();

            if (string.IsNullOrEmpty(base.text))
            {
                Init();
            }

            if (base.font == null)
            {
                LoadFont();
            }
        }

        void LoadFont()
        {
            base.font = (TMP_FontAsset)icon.Font.TMP_Font;
            base.LoadFontAsset();
        }

        void Init()
        {
            base.text = "\ue84d";
            base.font = null;
            base.color = new Color(0.196f, 0.196f, 0.196f, 1.000f);
            base.material = null;
            base.richText = false;
            base.verticalAlignment = VerticalAlignmentOptions.Middle;
            base.horizontalAlignment = HorizontalAlignmentOptions.Center;
            base.fontSize = Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height);
        }

        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            base.fontSize = Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height);
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            LoadFont();
            Init();
        }

        protected override void OnValidate()
        {
            base.font = (TMP_FontAsset)icon.Font.TMP_Font;
            base.text = icon.Text;
            base.LoadFontAsset();
            base.OnValidate();
            base.SetLayoutDirty();
        }

        public void UpdateIcon(MDTextIcon icon)
        {
            this.icon = icon;
            LoadFont();
            base.text = icon.Text;
        }
#endif

    }

}
