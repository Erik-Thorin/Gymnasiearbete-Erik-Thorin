using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject cleanlinessUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] PlayerMovement playerMovement;
    bool isPauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPauseMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPauseMenu == false)
        {
            OpenPauseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPauseMenu == true)
        {
            ClosePauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        playerMovement.canMove = false;
        Time.timeScale = 0f;
        cleanlinessUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        isPauseMenu = true;
        print("Open Menu");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        playerMovement.canMove = true;
        cleanlinessUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        isPauseMenu = false;
        print("Close Menu");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
