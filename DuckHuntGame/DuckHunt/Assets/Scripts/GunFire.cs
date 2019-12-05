using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BulletHitDelegate();
public class GunFire : MonoBehaviour
{
    public static BulletHitDelegate bulletHitEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 5);
                Debug.Log("Did Hit");
                bulletHitEvent?.Invoke();
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 5);
                Debug.Log("Did not Hit");
            }

        }
#endif
#if UNITY_IOS
#endif
    }
}
