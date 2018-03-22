using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfAction : MonoBehaviour {

    public PowersController MyPlayerPowerController;
    Obstacle obs;
    AudioSource sounfFX;
    public GameObject healOBJ;
    AudioSource healFX;


    // Use this for initialization
    void Start () {

        sounfFX = GetComponent<AudioSource>();
        healFX = healOBJ.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "obstacle")
        {
            if (MyPlayerPowerController == null)
            {
                Debug.Log("atach the PowersControllerScript");
            }
            else
            {
                

                obs = coll.gameObject.GetComponent<Obstacle>();
                int obsTypeLoc = obs.GetObsType();
                int dmg = obs.GetDmg();
                int heal = obs.getHealQuant();
                MyPlayerPowerController.ReportCollision(obsTypeLoc, dmg, heal);
                Destroy(coll.gameObject);

                if(obsTypeLoc == 1|| obsTypeLoc == 2)
                {
                    sounfFX.Play();

                }
                else
                {
                    healFX.Play();
                }
            }

        }
    }
}
