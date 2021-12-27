using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]


public class monster : MonoBehaviour
{
    public GameObject viking;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(viking.transform.position.x, viking.transform.position.y, viking.transform.position.z - 5);

    }



}
