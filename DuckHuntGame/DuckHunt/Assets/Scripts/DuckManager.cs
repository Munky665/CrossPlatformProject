using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{

    float duckActivator;
    [SerializeField]
    float timeHolder = 5;
    float waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //set wait time
        duckActivator = timeHolder;
    }

    // Update is called once per frame
    void Update()
    {
        //count down
        duckActivator -= 1 * Time.deltaTime;
        //activate duck and reset timer
        if (duckActivator < 1)
        {
            ActivateDuck();
            duckActivator = timeHolder;
        }
    }

    void ActivateDuck()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            if (ObjectPooler.Instance.GetPoolObject("Duck").activeInHierarchy == false)
            {
                ObjectPooler.Instance.GetPoolObject("Duck").SetActive(true);
            }

        }
    }

    

    void WaveIncrease()
    {
        waveNumber++;
    }
}
