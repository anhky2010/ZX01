using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {
	public GameObject Shot1;
 
	public GameObject Wave;
	public float Disturbance = 0;

	public int ShotType = 0;

	private GameObject NowShot;
	// Use this for initialization
	void Start () {
		NowShot = null;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
