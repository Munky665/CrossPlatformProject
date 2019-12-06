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
    float directionTimer = 0;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        origin = transform.position;
        GunFire.bulletHitEvent += RestDuck;
    }

    // Update is called once per frame
    void Update()
    {
        var RightVector = new Vector3(1, 1, 0);
        var LeftVector = new Vector3(-1, 1, 0);
        float temp = 0;

        if (directionTimer < 1)
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
                transform.Translate(RightVector * moveSpeed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(LeftVector * moveSpeed * Time.deltaTime);
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
