using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : NarrativeEvent
{
    public override void Event()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
