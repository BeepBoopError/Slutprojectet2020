using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private Vector3 startOfSelectMousePos;
    public List<GameObject> selectedAnts;
    public GameObject selectorRectangle;
    


    // Start is called before the first frame update
    void Start()
    {
        selectorRectangle.transform.localScale = new Vector3(0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startOfSelectMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //(x1-(x1t-x2t),y1-(y1t-y2t)
            selectorRectangle.transform.position = new Vector3(startOfSelectMousePos.x - ((startOfSelectMousePos.x * 0.5f) - (currentPos.x * 0.5f)), startOfSelectMousePos.y - ((startOfSelectMousePos.y * 0.5f) - (currentPos.y * 0.5f)), 0f);
            selectorRectangle.transform.localScale = new Vector3(Mathf.Abs(startOfSelectMousePos.x - currentPos.x),Mathf.Abs(startOfSelectMousePos.y- currentPos.y), 1f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedAnts.Clear();

            selectedAnts.AddRange(GameObject.FindGameObjectsWithTag("Ant"));

            bool selectCheckLoopBool = true;

            int selectCheckLoopCount = 0;
            
            while(selectCheckLoopBool)
            {
                try
                {
                   if (selectedAnts[selectCheckLoopCount].GetComponent<AntBase>().isHover)
                    {
                        selectedAnts[selectCheckLoopCount].GetComponent<AntBase>().isSelect = true;
                        selectCheckLoopCount += 1;
                        //Debug.Log("Ant added");
                    } 
                   else
                    {
                        selectedAnts[selectCheckLoopCount].GetComponent<AntBase>().isSelect = false;
                        selectedAnts.RemoveAt(selectCheckLoopCount);
                        //Debug.Log("Ant removed");
                    }
                }
                catch 
                {
                    selectCheckLoopBool = false;
                    //Debug.Log("Loop Concluded");
                }
            }

            selectorRectangle.transform.localScale = new Vector3(0f,0f,0f);
            Debug.Log(selectedAnts.Count);
        }

        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < selectedAnts.Count; i++)
            {
                Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float randomRange = 0.1f * selectedAnts.Count;
                destination.x += Random.Range( -randomRange, randomRange);
                destination.y += Random.Range( -randomRange, randomRange);
                destination.z = 0;

                selectedAnts[i].GetComponent<AntBase>().Destination = destination;
            }
        }

    }
}
