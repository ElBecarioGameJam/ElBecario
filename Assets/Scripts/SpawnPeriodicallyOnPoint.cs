using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeriodicallyOnPoint : MonoBehaviour {

    public bool debug = false;
	public GameObject prototypeEntity;
	public float initDelay = 0f;
	public float  minPeriodInSec = 1f;
    public float  maxPeriodInSec = 1f;

    private bool disabled = false;
	// Use this for initialization
    void OnEnable()
    {
        int seed = debug ? 12345: System.DateTime.Today.Millisecond;
        Random.InitState(seed);
        if (maxPeriodInSec< minPeriodInSec) {
            float temp = maxPeriodInSec;
            maxPeriodInSec = minPeriodInSec;
            minPeriodInSec = temp;
        }
        disabled = false;
        StartCoroutine("CreateObject");
    }

    private IEnumerator CreateObject() {
        while (!disabled) {
            GameObject instance = Instantiate(prototypeEntity);
		    instance.transform.position = this.gameObject.transform.position;
            yield return new WaitForSeconds(Random.Range(minPeriodInSec, maxPeriodInSec));            
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        disabled = true;
    }
}
