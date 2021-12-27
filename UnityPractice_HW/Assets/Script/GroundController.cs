using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Ground_b;
    public GameObject Ground_left;
    public GameObject Ground_left_s;
    public GameObject Ground_back;
    public GameObject Ground_forward;
    public GameObject Ground_right;
    public GameObject Ground_right_s;
    public GameObject Empty;
    public GameObject Empty_b;
    public GameObject Empty_l;
    public GameObject Empty_r;

    public bool turn = false;
    GameObject Next;
    GameObject NextEmpty;
    Vector3 NextPointe;
    private int rotation = 0;
    public int spawnCount = 0;
    int direction = 0;
    int turn_times = 0;
    public void SpawnTile()
    {
       
        GameObject temp;
        spawnCount++;
        if (spawnCount == 9)
        {
            turn_times++;
            turn = true;
           
            if(turn_times == 2)
            {
                turn_times = 0;
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 1;
                }
            }
            else
                 direction = Random.Range(0, 3);
            if (direction == 1)
            {
                rotation += 270;
            }
            else if  (direction == 2)
            {
                rotation += 90;
            }

            spawnCount = 0;

        }
        else
            turn = false;
        Rotate();
        if( spawnCount == 7)
            temp = Instantiate(NextEmpty, NextPointe, Quaternion.identity);
        else
            temp = Instantiate(Next, NextPointe, Quaternion.identity);
        //int rn= Random.Range(0, 2);
        NextPointe = temp.transform.GetChild(1).transform.position;

        


    }
    public void Rotate()
    {
        if (turn )
        {
            if (!turn && rotation % 360 == 0)
            {
                Next = Ground_forward;
            }
            else if (!turn && rotation % 360 == 90)
            {
                Next = Ground_right;
            }
            else if (!turn && rotation % 360 == 270)
            {
                Next = Ground_left;
            }
            else if (!turn && rotation % 360 == 180)
            {
                Next = Ground_back;
               
            }
        }
        else if(!turn)
        {
            if (!turn && rotation % 360 == 0)
            {
                Next = Ground;
                NextEmpty = Empty;
            }
            else if (!turn && rotation % 360 == 90)
            {
                Next = Ground_right_s;
                NextEmpty = Empty_r;
            }
            else if (!turn && rotation % 360 == 270)
            {
                Next = Ground_left_s;
                NextEmpty = Empty_l;
            }
            else if (!turn && rotation % 360 == 180)
            {
                Next = Ground_b;
                NextEmpty = Empty_b;
            }
        }
        

    }
    
    void Start()
    {
        SpawnTile();
    }
    private void Update()
    {
        SpawnTile();
    }


}
