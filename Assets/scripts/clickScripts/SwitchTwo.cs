using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTwo : MonoBehaviour {
    public bool switch2;
    public Camera gameCamera;
    public LayerMask actionMask;
    public SelectedArea selectedArea;
    bool touchOnce = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2) || Input.GetMouseButtonUp(3))
        {
            touchOnce = true;
        }
        if (Physics.Raycast(ray, out hitInfo, 100,actionMask))
        {
            if (touchOnce)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(3))
                {
                    if (switch2)
                    {
                        selectedArea.SwitchTwo();

                    }
                    touchOnce = false;
                }

            }
        }
        }
    }
