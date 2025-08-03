using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ManageLoopVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer vidP;
    [SerializeField] RawImage vidImage;
    [SerializeField] GameObject HouseDestroyVideoObj;

    [SerializeField] float AccelerateOpacitySpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public IEnumerator PlayEndVid()
    {
        HouseDestroyVideoObj.SetActive(true);
        vidImage.color = new Color(1, 1, 1, 0);
        while (vidImage.color.a < 1)
        {
            vidImage.color += new Color(0, 0, 0, Time.deltaTime* AccelerateOpacitySpeed);
            yield return null;
        }
        vidP.Play();

        yield return new WaitForSeconds((float)vidP.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
