
using UnityEngine;
using UnityEngine.UI;

namespace Google.MaterialDesign.Icons
{

    public class MaterialIconUGUI : Text
    {
        [SerializeField] MDTextIcon icon;

        protected override void Start()
        {
            base.Start();

            if (string.IsNullOrEmpty(base.text))
            {
                Init();
            }
            base.font = icon.Font.Font;
        }

        /// <summary> Properly initializes base Text class. </summary>
        public void Init()
        {
            base.text = icon.Text;
            base.font = icon.Font.Font;
            base.color = new Color(0.196f, 0.196f, 0.196f, 1.000f);
            base.material = null;
            base.alignment = TextAnchor.MiddleCenter;
            base.supportRichText = false;
            base.horizontalOverflow = HorizontalWrapMode.Overflow;
            base.verticalOverflow = VerticalWrapMode.Overflow;
            base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));
        }

        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));
        }

        public void UpdateIcon(MDTextIcon icon)
        {
            this.icon = icon;
            base.font = icon.Font.Font;
            base.text = icon.Text;
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            Init();
        }

        protected override void OnValidate()
        {
            base.font = icon.Font.Font;
            base.text = icon.Text;
            base.OnValidate();
            base.SetLayoutDirty();
        }
#endif


    }

}
