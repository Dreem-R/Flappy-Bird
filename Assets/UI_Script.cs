using System.Threading;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public UnityEngine.UI.Image Ghosticon;
    private float Ghostabilitytimer = 3f;
    private float GHostabilityCoolDown = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timer;
    private bool isghostoff = false;
    private bool isghostactive = false;


    //Called after ghost is used
    private void Ghostused()
    {
        isghostoff = true;
        isghostactive = false;
        timer = 0;
    }


    //Called when ghost being used
    public void GhostActive()
    {
        isghostactive = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isghostoff)
        {
            timer += Time.deltaTime;
            Ghosticon.fillAmount = timer / GHostabilityCoolDown;

            if (timer >= GHostabilityCoolDown)
            {
                timer = 0;
                isghostoff = false;
            }
        }
        else if (isghostactive)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * 10f));
            Color color = Ghosticon.color;
            color.a = alpha;
            Ghosticon.color = color;
            if (timer >= Ghostabilitytimer)
            {
                Ghostused();
                color.a = 1;
                Ghosticon.color = color; //Reset Alpha to 1
            }
        }
    }
}
