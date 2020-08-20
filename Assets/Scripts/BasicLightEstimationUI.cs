﻿using System;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// A simple UI controller to display basic light estimation information.
    /// </summary>
    [RequireComponent(typeof(BasicLightEstimation))]
    public class BasicLightEstimationUI : MonoBehaviour
    {
        [Tooltip("The UI Text element used to display the estimated ambient intensity in the physical environment.")]
        [SerializeField]
        Text m_AmbientIntensityText;

        /// <summary>
        /// The UI Text element used to display the estimated ambient intensity value.
        /// </summary>
        public Text ambientIntensityText
        {
            get { return m_AmbientIntensityText; }
            set { m_AmbientIntensityText = ambientIntensityText; }
        }

        [Tooltip("The UI Text element used to display the estimated ambient color in the physical environment.")]
        [SerializeField]
        Text m_AmbientColorText;

        /// <summary>
        /// The UI Text element used to display the estimated ambient color in the scene.
        /// </summary>
        public Text ambientColorText
        {
            get { return m_AmbientColorText; }
            set { m_AmbientColorText = value; }
        }

        void Awake()
        {
            m_LightEstimation = GetComponent<BasicLightEstimation>();
        }

        void Update()
        {
            SetUIValue(m_LightEstimation.brightness, ambientIntensityText);

            //Display color temperature or color correction if supported
            if (m_LightEstimation.colorTemperature != null)
                SetUIValue(m_LightEstimation.colorTemperature, ambientColorText);
            else if (m_LightEstimation.colorCorrection != null)
                SetUIValue(m_LightEstimation.colorCorrection, ambientColorText);
            else
                SetUIValue<float>(null, ambientColorText);
        }
        
        void SetUIValue<T>(T? displayValue, Text text) where T : struct
        {
            if (text != null)
                text.text = displayValue.HasValue ? displayValue.Value.ToString(): "Unavailable";
        }

        BasicLightEstimation m_LightEstimation;
    }
}