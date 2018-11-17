using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPeriodicallyOnArea : MonoBehaviour {



	public bool debug = false;
	public GameObject prototypeEntity;
	public float initDelay = 0f;
	public float  minPeriodInSec = 1f;
    public float  maxPeriodInSec = 1f;
	public bool onX = true;
	public bool onY = true;

    private bool disabled = false;
	private float minX, minY, maxX, maxY; 
	// Use this for initialization
    void OnEnable()
    {	
		Renderer r = GetComponent<Renderer>();
		minX = r.bounds.min.x;
		minY = r.bounds.min.y;
		maxX = r.bounds.max.x;
		maxY = r.bounds.max.y;
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
			float x = this.gameObject.transform.position.x;
			float y = this.gameObject.transform.position.y;
			float z = this.gameObject.transform.position.z;
			if (onX) {
				x = Random.Range(minX, maxX);
			}

			if (onY) {
				y = Random.Range(minY, maxY);
			}
			instance.transform.position = new Vector3(x,y,z);
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
