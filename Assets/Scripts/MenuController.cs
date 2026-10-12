using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitButton()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
