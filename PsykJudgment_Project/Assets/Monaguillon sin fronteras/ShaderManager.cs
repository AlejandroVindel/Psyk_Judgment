using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    public Material material;
    public float duration = 0.2f;
    private float timer = 0;
  
    // Update is called once per frame
    void Update()
    {
        if((timer += Time.deltaTime) > duration)
        {
            timer = 0;
            enabled = false;
        }
    }

    public void Play()
    {
        enabled = true;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
