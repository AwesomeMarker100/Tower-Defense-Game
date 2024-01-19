using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update

    ParticleSystem ps;
   

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMidColor()
    {
        var colorOverLifetime = ps.colorOverLifetime;
        Gradient midHurt = new Gradient();
        midHurt.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.red, 1.0f)}, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });


        colorOverLifetime.color = midHurt;

    }

    public void ChangeLastColor()
    {

        Gradient finalHurt = new Gradient();
        finalHurt.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.black, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        var colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.color = finalHurt;


    }
}
