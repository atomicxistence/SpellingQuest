using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance {get; private set;}

    private void Awake()
    {
        #region Singleton
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else if (SharedInstance != this)
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void ClickMain()
    {
        SceneManager.LoadScene(0);
    }
}