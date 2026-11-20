using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoldToLook : MonoBehaviour
{
    CinemachineInputAxisController inputController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputController = GetComponent< CinemachineInputAxisController> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        bool isHoldRightClick = Input.GetMouseButton(0);

        if (inputController != null)
        {
            inputController.enabled = isHoldRightClick;
        }
        Cursor.lockState = isHoldRightClick ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isHoldRightClick;
    }
}
