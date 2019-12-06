using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{

    float duckActivator;
    public float timeHolder = 5;
    public WaveManager waveManager;

    int duckToActivate = 0;
    int maxDucks = 9;
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
        if (duckToActivate > maxDucks)
        {
            duckToActivate = 0;
        }
        ObjectPooler.Instance.GetPooledDuck("Duck", duckToActivate).SetActive(true);
        duckToActivate++;
    }

    

    void WaveIncrease()
    {
        waveManager.wave++;
    }

    private void OnDestroy()
    {
        waveManager.wave = 1;
    }
}
