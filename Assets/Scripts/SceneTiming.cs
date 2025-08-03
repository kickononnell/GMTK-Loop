using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTiming : MonoBehaviour
{
    public float timer;
    public float timerToResetInSeconds = 400f;
    private bool isStarted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            timer += Time.deltaTime;
            if (timer > timerToResetInSeconds) ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartTimer()
    {
        isStarted = true;
    }
}
