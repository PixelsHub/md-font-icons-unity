
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

namespace Google.MaterialDesign.Icons
{

public class MaterialIconTMP : TMPro.TextMeshProUGUI
{
	[HideInInspector] [SerializeField] int fontStyleIndex = 0;
	[HideInInspector] [SerializeField] MaterialIconConfig iconConfig;
	public string iconUnicode
	{
		get { return System.Convert.ToString(char.ConvertToUtf32(base.text, 0), 16); }
		set { base.text = char.ConvertFromUtf32(System.Convert.ToInt32(value, 16)); }
	}

	public MaterialIconConfig.FontStyle FontStyleData { get { if (iconConfig == null) return default(MaterialIconConfig.FontStyle); else return iconConfig.FontStyles[fontStyleIndex];  } }

	protected override void Start()
	{
		base.Start();

		if(string.IsNullOrEmpty(base.text))
		{
			Init();
		}

		#if UNITY_EDITOR
		if(base.font == null)
		{
			LoadConfig();
		}
		#endif
	}

	#if UNITY_EDITOR
	protected override void Reset()
	{
		base.Reset();
		Init();
		LoadConfig();
	}

	protected override void OnValidate()
	{
		if (iconConfig == null) LoadConfig();
		if (iconConfig != null) base.font = (TMP_FontAsset) iconConfig.FontStyles[fontStyleIndex].TMP_Font;
			base.LoadFontAsset();
            base.OnValidate();
		base.SetLayoutDirty();
	}

	/// <summary> Searches for the \"MaterialIcons-Regular\" font inside the project. </summary>
	public void LoadConfig()
	{
		string[] guid = UnityEditor.AssetDatabase.FindAssets("t:MaterialIconConfig");
		if (guid.Length == 0) return;
		else
		{
			string assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid[0]);
			iconConfig = UnityEditor.AssetDatabase.LoadAssetAtPath<MaterialIconConfig>(assetPath);
			base.font = (TMP_FontAsset)iconConfig.FontStyles[fontStyleIndex].TMP_Font;
				base.LoadFontAsset();
            }
	}
#endif

		/// <summary> Properly initializes base Text class. </summary>
		public void Init()
	{
		base.text = "\ue84d";
		base.font = null;
		base.color = new Color(0.196f, 0.196f, 0.196f, 1.000f);
		base.material = null;
	
		//base.alignment = TextAnchor.MiddleCenter;
		//base.supportRichText = false;
		//base.horizontalOverflow = HorizontalWrapMode.Overflow;
		//base.verticalOverflow = VerticalWrapMode.Overflow;
		base.richText = false;
			base.verticalAlignment = VerticalAlignmentOptions.Middle;
			base.horizontalAlignment = HorizontalAlignmentOptions.Center;
		base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));
	}

	protected override void OnRectTransformDimensionsChange()
	{
		base.OnRectTransformDimensionsChange();
		base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));
	}

}

}
