using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    const int snapSize = 10;
    public bool isExplored = false;

    public bool isUsable = true;
    public CheckPoint exploredFrom;




    void Start()
    {
        
    }

    public int GetSnapSize()
    {

        return snapSize;


    }

    public Vector2Int GetSnapLocation()
    {

        return new Vector2Int(

              Mathf.RoundToInt(transform.position.x / snapSize),//uses the Mathf.Round() function to snap the cube every 10 spaces
              Mathf.RoundToInt(transform.position.z / snapSize)

        );
    }
    // Update is called once per frame
 

   

        
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isUsable)
        {
            FindObjectOfType<TowerMill>().AddTower(this);
            this.isUsable = false;

        }
       

    }
    

}
