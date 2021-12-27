using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnSpeed = 50f;
    private void OnTriggerEnter(Collider other)
    {
        //Check that if the object collided with the coin is the player
        if(other.gameObject.name == "viking")
        {
            //Add to the Player's score
            GameManager.inst.IncrementScore();
            //Destroy this coin object
            Destroy(gameObject);
            return;
        }
        else return;
    }
    void Start()
    {       

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime , 0 ,0);
    }
}
