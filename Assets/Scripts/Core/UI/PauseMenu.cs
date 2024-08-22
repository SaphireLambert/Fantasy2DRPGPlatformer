using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler playerInputHandler;
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
        playerInputHandler.playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
