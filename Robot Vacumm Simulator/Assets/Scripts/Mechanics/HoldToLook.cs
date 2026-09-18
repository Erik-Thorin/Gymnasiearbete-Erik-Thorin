using UnityEngine;
using Unity.Cinemachine;
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
        bool isHoldRightClick = Input.GetMouseButton(0);

        if (inputController != null)
        {
            inputController.enabled = isHoldRightClick;
        }
        Cursor.lockState = isHoldRightClick ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isHoldRightClick;
    }
}
