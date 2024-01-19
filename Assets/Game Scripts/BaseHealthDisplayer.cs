using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    Text textMesh;
    BaseDamager bd;
    void Start()
    {
        textMesh = GetComponent<Text>();
        bd = FindObjectOfType<BaseDamager>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text =   bd.GetHealth().ToString();

    }
}
