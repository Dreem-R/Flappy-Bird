using System.Threading;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public UnityEngine.UI.Image Ghosticon;
    private float Ghostabilitytimer = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timer;
    private bool isghostoff = false;

    public void Ghostused()
    {
        isghostoff = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isghostoff)
        {
            timer += Time.deltaTime;
            Ghosticon.fillAmount = timer / Ghostabilitytimer;

            if (timer >= Ghostabilitytimer)
            {
                timer = 0;
                isghostoff = false;
            }
        }
    }
}
