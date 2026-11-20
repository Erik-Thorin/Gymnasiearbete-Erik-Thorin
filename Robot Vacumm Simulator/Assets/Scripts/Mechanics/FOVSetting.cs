using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FOVSetting : MonoBehaviour
{
    [SerializeField] Text valueText;
    Slider fovSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fovSlider = GetComponent<Slider>();

        float savedFOV = PlayerPrefs.GetFloat(CameraFOVController.FOVPrefKey, CameraFOVController.DefaultFOV);
        fovSlider.value = savedFOV;
        UpdateFOVText(savedFOV);
        fovSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.GetString(fovSlider.value) = valueText.text = fovSlider.value.ToString();
        //PlayerPrefs.SetFloat(fovSlider.value);

    }

    void OnSliderChanged(float newFOV)
    {
        PlayerPrefs.SetFloat(CameraFOVController.FOVPrefKey, newFOV);
        PlayerPrefs.Save();
        UpdateFOVText(newFOV);
        CameraFOVController.BroadcastFOVChange(newFOV);
    }

    void UpdateFOVText(float fov)
    {
        if (valueText != null)
        {
            valueText.text = Mathf.RoundToInt(fov).ToString();
        }
    }
}
