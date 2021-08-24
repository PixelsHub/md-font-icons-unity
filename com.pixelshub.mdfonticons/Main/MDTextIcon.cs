using System;
using UnityEngine;

namespace Google.MaterialDesign.Icons
{
    [Serializable]
    public class MDTextIcon
    {
        [SerializeField] int style = 0;
        [SerializeField] MaterialIconConfig config;
        [SerializeField] string text = "\ue84d";

        public string Text { get { return this.text; } }
        public MaterialIconConfig.FontStyle Font { get { if (config == null) return default(MaterialIconConfig.FontStyle); else return config.FontStyles[style]; } }

    }
}
