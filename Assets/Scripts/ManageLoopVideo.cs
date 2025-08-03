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
    [SerializeField] AudioSource vidAudSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(PlayEndVid());
    }

    public IEnumerator PlayEndVid()
    {
        HouseDestroyVideoObj.SetActive(true);
        vidImage.color = new Color(1, 1, 1, 0);
        vidAudSrc.Play();
        vidP.Play();
        vidP.frame = 0;
        while (vidImage.color.a < 1)
        {
            vidImage.color += new Color(0, 0, 0, Time.deltaTime* AccelerateOpacitySpeed);
            yield return null;
        }
        

        yield return new WaitForSeconds((float)vidP.clip.length/5);
        HouseDestroyVideoObj.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
