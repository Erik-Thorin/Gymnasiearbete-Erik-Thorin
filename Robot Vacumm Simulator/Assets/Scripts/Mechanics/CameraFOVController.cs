using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraFOVController : MonoBehaviour
{
    public const string FOVPrefKey = "CameraFOV";
    public const float DefaultFOV = 60f;

    // Event triggered whenever the UI slider moves
    public static event Action<float> OnFOVChanged;

    private CinemachineCamera cineCamera;

    private void Awake()
    {
        cineCamera = GetComponent<CinemachineCamera>();
    }

    private void Start()
    {
        // Load saved FOV (or use DefaultFOV if none was saved yet)
        float savedFOV = PlayerPrefs.GetFloat(FOVPrefKey, DefaultFOV);
        ApplyFOV(savedFOV);
    }

    private void OnEnable()
    {
        OnFOVChanged += ApplyFOV;
    }

    private void OnDisable()
    {
        OnFOVChanged -= ApplyFOV;
    }

    private void ApplyFOV(float newFOV)
    {
        if (cineCamera == null)
        {
            return;
        }

        // Update the Lens Field of View on the CinemachineCamera
        cineCamera.Lens.FieldOfView = newFOV;
    }

    public static void BroadcastFOVChange(float newFOV)
    {
        if (OnFOVChanged != null)
        {
            OnFOVChanged.Invoke(newFOV);
        }
    }
}
