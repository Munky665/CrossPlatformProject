using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DuckMovment : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5;
    [SerializeField]
    float timer = 5;
    System.Random rand;
    float directionTimer = 1;
    Vector3 origin;
    float temp;
    // Start is called before the first frame update
    void OnEnable()
    {
        rand = new System.Random();
        origin = transform.position;
        GunFire.bulletHitEvent += RestDuck;
        temp = rand.Next(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //set direction vectors
        var RightVector = new Vector3(0, 1, 1);
        var LeftVector = new Vector3(0, 1, -1);

        //
        if (directionTimer < 0.5f)
        {
            temp = rand.Next(0, 2);
            directionTimer = timer;
        }
        else
        {
            directionTimer -= 1 * Time.deltaTime;
        }

        switch (temp)
        {
            case 0:
                transform.position +=  RightVector * moveSpeed * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(30,90,0);
                break;
            case 1:
                transform.position += LeftVector * moveSpeed * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(-30, -90, 0);
                break;
        }
    }

    void RestDuck()
    {
        if (this.gameObject.activeInHierarchy == false)
        {
            transform.position = origin;
        }
    }



}
