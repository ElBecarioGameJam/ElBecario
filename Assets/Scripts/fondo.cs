using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour {

    public float velocidadDesplazamiento;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * velocidadDesplazamiento * Time.deltaTime);
    }
   
}
