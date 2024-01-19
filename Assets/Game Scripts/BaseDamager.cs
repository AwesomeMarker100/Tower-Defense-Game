using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseDamager : MonoBehaviour
{

    [SerializeField] int healthPoints = 10;
    [SerializeField] AudioClip friendlyOuchSFX;

    ColorChanger[] cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectsOfType<ColorChanger>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {

            SceneManager.LoadScene(0);

        }
    }

    public void ReduceHealth()
    {

        healthPoints--;
        GetComponent<AudioSource>().PlayOneShot(friendlyOuchSFX);

        if(healthPoints <= 10)
        {
            foreach(ColorChanger c in cc)
            {

                c.ChangeMidColor();

            }
            

        }

        if (healthPoints <= 5) {

            foreach (ColorChanger c in cc)
            {

                c.ChangeLastColor();

            }

        }



    }

    public int GetHealth()
    {

        return healthPoints;

    }
}
