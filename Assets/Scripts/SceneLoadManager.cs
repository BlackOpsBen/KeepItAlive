using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance { get; private set; }

    private bool canRestart = false;

    private void Awake()
    {
        EnsureOnlyOneInstance();
    }

    void Update()
    {
        if (canRestart)
        {
            if (Input.GetButtonDown("Jump"))
            {
                canRestart = false;
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void EnsureOnlyOneInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetCanRestart(bool value)
    {
        canRestart = value;
    }
}
