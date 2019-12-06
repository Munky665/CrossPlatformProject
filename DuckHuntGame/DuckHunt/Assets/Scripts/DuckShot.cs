using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShot : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GunFire.bulletHitEvent += DuckWasShot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DuckWasShot()
    {
        this.gameObject.SetActive(false);
    }
}
