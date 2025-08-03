using UnityEngine;

public class GifMat : MonoBehaviour
{
    public Material targetMaterial;
    public Texture[] gifFrames;
    public float frameRate = 10f;

    private int currentFrame;
    private float timer;

    void Update()
    {
        if (gifFrames.Length == 0 || targetMaterial == null) return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % gifFrames.Length;
            targetMaterial.mainTexture = gifFrames[currentFrame];
        }
    }
}
