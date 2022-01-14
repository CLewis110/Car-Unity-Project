using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] Transform objToCreateBtnsFor;
    [SerializeField] GameObject btnPrefab;
    [SerializeField] Transform btnStartPoint;
    private Vector3 currSpawnPoint;
    private Vector3 btnOffset = new Vector3(0, -30f, 0);

    void Start()
    {
        CreateButtons();
        currSpawnPoint = btnStartPoint.position;
    }
    
    public void CreateButtons()
    {
        //For each child of obj
        int children = objToCreateBtnsFor.transform.childCount;

        for(int i = 0; i < children; i++)
        {
            //Create button as a child of this gameobject
            GameObject currButton = Instantiate(btnPrefab, currSpawnPoint, Quaternion.identity);

            //Rename button and text the same as the obj.child
            currButton.name = objToCreateBtnsFor.GetChild(i).name;
            Text textObj = currButton.GetComponentInChildren<Text>();
            textObj.text = objToCreateBtnsFor.GetChild(i).name;

            //Move each button's Y value down a bit
            //RectTransform currBtnPos = currButton.GetComponent<RectTransform>();
            //currBtnPos.position = btnStartPoint.transform.position;
            //btnStartPoint.transform.position += btnOffset;
            currSpawnPoint += btnOffset;
        }


    }

}
