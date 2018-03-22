using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualGem : MonoBehaviour {
    public GameObject[] prefabGround = new GameObject[4];
    public GameObject spawnY1;
    public GameObject spawnY2;
    public GameObject spawnY3;

    public Transform spawnPoint;
    public Transform newSpawnPoint;
    public GameObject grounds;
    public GameObject player;

    public SelectedArea areaForLevelGem;
    private int level;
    private int oldLevel;
    private int levelBetween;
    public int quantOflevelTrans;
     int levelMulti = 0;
    private int quantOfSpawnsLayer = 1;
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefabNew;


    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefabNew2;


    public GameObject obstaclePrefab3;
    public GameObject obstaclePrefabNew3;

    public Transform spawnObs1;
    public Transform SpawnObs2;
    public Transform spawnObs3;

    bool doOneTime = true;
    float moveSpeed = 6;
    Vector3 velocity;
    float gravity;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float jumpVelocity;
    float velocityXSmoothing;
    float accelerationTimeGrounded = .1f;




    // Use this for initialization
    void Start () {
        level = areaForLevelGem.GetLevel();
        oldLevel = level;

    }

    // Update is called once per frame
    void Update () {
        //movement da camera

        /*if(player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }*/
        if (obstaclePrefab == null)
        {
            obstaclePrefab = obstaclePrefabNew;
        }
        if (obstaclePrefab2 == null)
        {
            obstaclePrefab2 = obstaclePrefabNew2;
        }
        if (obstaclePrefab3 == null)
        {
            obstaclePrefab3 = obstaclePrefabNew3;
        }
        level = areaForLevelGem.GetLevel();
        if(level != oldLevel)
        {
            doOneTime = true;
            levelBetween++;
            if (quantOfSpawnsLayer == 1)
            {
                int place = Random.Range(1, 4);
                if(place == 1)
                {
                    obstaclePrefab = Instantiate(obstaclePrefab);
                    obstaclePrefab.transform.position = spawnObs1.position;
                    Obstacle settingObsValues = obstaclePrefab.GetComponent<Obstacle>();
                    int Type = Random.Range(1, 4);
                    settingObsValues.SetObsType(Type);
                    if(Type == 1)
                    {
                        settingObsValues.SetDmg(10 + levelMulti);
                    }if (Type == 2)
                    {
                        settingObsValues.SetDmg(5 + levelMulti);

                    }
                    if (Type == 3)
                    {
                        settingObsValues.setHealQuant(5 + levelMulti);
                        settingObsValues.SetDmg(0);

                    }
                }
                else if(place == 2)
                {
                    obstaclePrefab = Instantiate(obstaclePrefab);
                    obstaclePrefab.transform.position = SpawnObs2.position;
                    Obstacle settingObsValues = obstaclePrefab.GetComponent<Obstacle>();
                    int Type = Random.Range(1, 4);
                    settingObsValues.SetObsType(Type);
                    if (Type == 1)
                    {
                        settingObsValues.SetDmg(10 + levelMulti);
                    }
                    if (Type == 2)
                    {
                        settingObsValues.SetDmg(5 + levelMulti);

                    }
                    if (Type == 3)
                    {
                        settingObsValues.setHealQuant(5 + levelMulti);
                        settingObsValues.SetDmg(0);


                    }

                }
                else if (place == 3)
                {
                    obstaclePrefab = Instantiate(obstaclePrefab);
                    obstaclePrefab.transform.position = spawnObs3.position;
                    Obstacle settingObsValues = obstaclePrefab.GetComponent<Obstacle>();
                    int Type = Random.Range(1, 4);
                    settingObsValues.SetObsType(Type);
                    if (Type == 1)
                    {
                        settingObsValues.SetDmg(10 + levelMulti);
                    }
                    if (Type == 2)
                    {
                        settingObsValues.SetDmg(5 + levelMulti);

                    }
                    if (Type == 3)
                    {
                        settingObsValues.setHealQuant(5 + levelMulti);
                        settingObsValues.SetDmg(0);

                    }

                }
            }
            else if(quantOfSpawnsLayer == 2)
            {
                if (doOneTime)
                {
                    obstaclePrefab = Instantiate(obstaclePrefab);
                    obstaclePrefab.transform.position = spawnObs1.position;
                    Obstacle settingObsValues = obstaclePrefab.GetComponent<Obstacle>();
                    int Type = Random.Range(1, 4);
                    settingObsValues.SetObsType(Type);
                    if (Type == 1)
                    {
                        settingObsValues.SetDmg(10 + levelMulti);
                    }
                    if (Type == 2)
                    {
                        settingObsValues.SetDmg(5 + levelMulti);

                    }
                    if (Type == 3)
                    {
                        settingObsValues.setHealQuant(5 + levelMulti);
                        settingObsValues.SetDmg(0);

                    }
                    

                    obstaclePrefab3 = Instantiate(obstaclePrefab3);
                    obstaclePrefab3.transform.position = spawnObs3.position;
                    Obstacle settingObsValues3 = obstaclePrefab3.GetComponent<Obstacle>();
                    int Type3 = Random.Range(1, 4);
                    settingObsValues3.SetObsType(Type3);
                    if (Type3 == 1)
                    {
                        settingObsValues3.SetDmg(10 + levelMulti);
                    }
                    if (Type3 == 2)
                    {
                        settingObsValues3.SetDmg(5 + levelMulti);

                    }
                    if (Type3 == 3)
                    {
                        settingObsValues3.setHealQuant(10 + levelMulti);
                        settingObsValues.SetDmg(0);
                    }
                    doOneTime = false;
                }
            }
            else if (quantOfSpawnsLayer >= 3)
            {
                obstaclePrefab = Instantiate(obstaclePrefab);
                obstaclePrefab.transform.position = spawnObs1.position;
                Obstacle settingObsValues = obstaclePrefab.GetComponent<Obstacle>();
                int Type = Random.Range(1, 4);
                settingObsValues.SetObsType(Type);
                if (Type == 1)
                {
                    settingObsValues.SetDmg(10 + levelMulti);
                }
                if (Type == 2)
                {
                    settingObsValues.SetDmg(5 + levelMulti);

                }
                if (Type == 3)
                {
                    settingObsValues.setHealQuant(5 + levelMulti);
                    settingObsValues.SetDmg(0);

                }

                obstaclePrefab2 = Instantiate(obstaclePrefab2);
                obstaclePrefab2.transform.position = SpawnObs2.position;
                Obstacle settingObsValues2 = obstaclePrefab2.GetComponent<Obstacle>();
                int Type2 = Random.Range(1, 4);
                settingObsValues2.SetObsType(Type2);
                if (Type2 == 1)
                {
                    settingObsValues2.SetDmg(10 + levelMulti);
                }
                if (Type2 == 2)
                {
                    settingObsValues2.SetDmg(5 + levelMulti);

                }
                if (Type2 == 3)
                {
                    settingObsValues2.setHealQuant(5 + levelMulti);
                    settingObsValues2.SetDmg(0);

                }



                obstaclePrefab3 = Instantiate(obstaclePrefab3);
                obstaclePrefab3.transform.position = spawnObs3.position;
                Obstacle settingObsValues3 = obstaclePrefab3.GetComponent<Obstacle>();
                int Type3 = Random.Range(1, 4);
                settingObsValues3.SetObsType(Type3);
                if (Type3 == 1)
                {
                    settingObsValues3.SetDmg(10 + levelMulti);
                }
                if (Type3 == 2)
                {
                    settingObsValues3.SetDmg(5 + levelMulti);

                }
                if (Type3 == 3)
                {
                    settingObsValues3.setHealQuant(5 + levelMulti);
                    settingObsValues2.SetDmg(0);


                }

            }
            //instantiate all gameObjects
            oldLevel = level;
        }
        if(levelBetween >= quantOflevelTrans)
        {
            levelMulti = levelMulti + 5;
            levelBetween = 0;
            quantOfSpawnsLayer++;
        }



        if (spawnPoint.position.x >= newSpawnPoint.position.x)
        {
            int pos = Random.Range(0, 2);
            prefabGround[pos] = Instantiate(prefabGround[pos]);
            prefabGround[pos].transform.position = new Vector3(newSpawnPoint.transform.position.x, spawnY1.transform.position.y, newSpawnPoint.transform.position.z);
            prefabGround[pos].transform.parent = grounds.transform;
            prefabGround[pos] = Instantiate(prefabGround[pos]);
            prefabGround[pos].transform.position = new Vector3(newSpawnPoint.transform.position.x, spawnY2.transform.position.y, newSpawnPoint.transform.position.z);
            prefabGround[pos].transform.parent = grounds.transform;
            prefabGround[pos] = Instantiate(prefabGround[pos]);
            prefabGround[pos].transform.position = new Vector3(newSpawnPoint.transform.position.x, spawnY3.transform.position.y, newSpawnPoint.transform.position.z);
            prefabGround[pos].transform.parent = grounds.transform;

            newSpawnPoint.transform.position = new Vector3(newSpawnPoint.transform.position.x + 10, newSpawnPoint.transform.position.y, newSpawnPoint.transform.position.z);

        }

    }
}
