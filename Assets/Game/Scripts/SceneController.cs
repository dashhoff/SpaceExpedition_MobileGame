using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(name);
    }

    public void LoadScene(int id)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(id);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
