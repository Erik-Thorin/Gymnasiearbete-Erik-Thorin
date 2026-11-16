using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject mainMenuObject;
    [SerializeField] GameObject settingsObject;
    [SerializeField] GameObject worldsMenuObject;
    [SerializeField] GameObject world1LevelsObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        mainMenuObject.SetActive(true);
        settingsObject.SetActive(false);
        worldsMenuObject.SetActive(false);
        world1LevelsObject.SetActive(false);
    }

    public void GoToSettings()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(true);
        worldsMenuObject.SetActive(false);
        world1LevelsObject.SetActive(false);
    }

    public void GoToWorldsMenu()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(false);
        worldsMenuObject.SetActive(true);
        world1LevelsObject.SetActive(false);
    }

    public void GoToWorld1LevelsMenu()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(false);
        worldsMenuObject.SetActive(false);
        world1LevelsObject.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayWorld1Level1()
    {
        SceneManager.LoadScene("World 1 Level 1");
    }
}
