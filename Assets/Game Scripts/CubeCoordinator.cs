using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]//runs code in scene mode or edit modde
[SelectionBase]//makes it harder for you to click on specific surface so that you grab the entire cube
[RequireComponent(typeof(CheckPoint))]
public class CubeCoordinator : MonoBehaviour
{



    Vector2Int realSnapLocation;
    CheckPoint checkPoint;
    int snapSize;
   
   

    private void Awake()
    {

        checkPoint = GetComponent<CheckPoint>();
        

    }

    void Start()
    {

        
    }



    void Update()
    {

        snapSize = checkPoint.GetSnapSize();
        realSnapLocation = checkPoint.GetSnapLocation();
        

        CubeSnapper(realSnapLocation * snapSize);
        CreateCoordinates(realSnapLocation);
    }

    private void CubeSnapper(Vector2Int realSnapLocation)
    {

        transform.position = new Vector3(realSnapLocation.x, -5f, realSnapLocation.y);
        
    }

    private void CreateCoordinates(Vector2Int snapLocation)
    {
        
        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        string cubeCoords = snapLocation.x + "," + snapLocation.y;

        RenameCube(cubeCoords);

        textMesh.text = cubeCoords; //sets text on cube to the coordinates it is at


    }

    private void RenameCube(string cubeCoords)
    {

        gameObject.name = "Cube: " + cubeCoords;

    }
}
