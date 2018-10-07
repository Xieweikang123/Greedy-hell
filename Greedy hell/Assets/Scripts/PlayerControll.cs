using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 3.0f;
    private float v, h;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);
	}
}
