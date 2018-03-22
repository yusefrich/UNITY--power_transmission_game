using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickDetect : MonoBehaviour {
    public bool jump;
    public bool switch1;
    public bool switch2;

    public Camera gameCamera;
    public LayerMask actionMask;

    public Player player1;
    public Player player2;
    public Player player3;
    public SelectedArea selectedArea;

    bool touchOnce = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2) || Input.GetMouseButtonUp(3))
        {
            touchOnce = true;
        }
        if (Physics.Raycast(ray, out hitInfo, actionMask))
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
            if (touchOnce)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(3))
                {
                    if (switch1)
                    {
                        selectedArea.SwitchOne();
                    }
                    if (switch2)
                    {
                        selectedArea.SwitchTwo();

                    }
                    if (jump)
                    {
                        player1.Jump();
                        player2.Jump();
                        player3.Jump();
                    }
                    touchOnce = false;
                }
            }
        }


    }
}
