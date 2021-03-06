﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController :  MonoBehaviour  {  

	public float verticalSpeed = 5f;
//	public float horizontalSpeed = 0.01f;
	private int tick;

	int estadoHumano = 1; //estado 1 = corriendo; estado 2 = muerto;
	public int anatomia; // 1= humano; 2= aguila; 3= tigre; 4= roedor;

	public GameObject mainCamera;

	int counts = 0; 
	// Use this for initialization
	void Start () {
//		gameObject.GetComponent<Rigidbody> ().velocity += new Vector3 (0, 0, horizontalSpeed);
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (anatomia);


		if (Input.GetKeyDown (KeyCode.Alpha1) && anatomia != 1) {
			Cambio ();
			updateIndex (1);
			//gameObject.GetComponent<Rigidbody> ().useGravity = true;
			Debug.Log (gameObject.name + " ; Forma = " + anatomia + " y recibio tecla: 1");
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && anatomia != 2) {
			Cambio ();
			updateIndex (2);
			//gameObject.GetComponent<Rigidbody> ().useGravity = false;
			Debug.Log (gameObject.name + " ; Forma = " + anatomia + " y recibio tecla: 2");
		}

		if (Input.GetKeyDown (KeyCode.Alpha3) && anatomia != 3) {
			Cambio ();
			updateIndex (3);
			//gameObject.GetComponent<Rigidbody> ().useGravity = true;
			Debug.Log (gameObject.name + " ; Forma = " + anatomia + " y recibio tecla: 3");
		}
		if (Input.GetKeyDown (KeyCode.Alpha4) && anatomia != 4) {
			Cambio ();
			updateIndex (4);
			//gameObject.GetComponent<Rigidbody> ().useGravity = true;
			Debug.Log ("Forma = " + anatomia);
		}




		if (anatomia == 1 && counts < 2) {		 
			
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				gameObject.GetComponent<Rigidbody> ().velocity += new Vector3 (0, verticalSpeed);
				counts++;
				Debug.Log ("counts: " + counts);
			}

		}

		if (anatomia == 2) {
			
			if (Input.GetKey (KeyCode.UpArrow) && gameObject.transform.position.y < 6) {
				gameObject.GetComponent<Rigidbody> ().velocity += new Vector3 (0, verticalSpeed / 3);
			}
			if (Input.GetKey (KeyCode.DownArrow) && gameObject.transform.position.y > 0) {
				gameObject.GetComponent<Rigidbody> ().velocity -= new Vector3 (0, verticalSpeed / 3);
			}
//			if (gameObject.transform.position.y > 6){
//				
//			}
		}

		if (anatomia == 3 && counts < 2) {		 
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				gameObject.GetComponent<Rigidbody> ().velocity += new Vector3 (0, verticalSpeed * 1.4f);
				counts++;
				Debug.Log ("counts: " + counts);
			}
		}

		if (anatomia == 4 && counts < 2) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				gameObject.GetComponent<Rigidbody> ().velocity += new Vector3 (0, verticalSpeed/3.2f);
				counts++;
				Debug.Log ("counts: " + counts);
			}
		}
	}

	void OnCollisionEnter (Collision col){
//		Debug.Log ("Collision");
//		Debug.Log ("Name " + col.gameObject.name);
		counts = 0;
		if (col.gameObject.name == "Pilar(Clone)" || col.gameObject.name == "Tronco(Clone)" || col.gameObject.name == "Bush(Clone)" 
			|| col.gameObject.name == "Tree(Clone)" || col.gameObject.name == "Tree 2(Clone)" || col.gameObject.name == "Tree 3(Clone)" 
			|| col.gameObject.name == "Tree 4(Clone)") {
			estadoHumano = 2;
			if (estadoHumano == 2) {
				Destroy (this.gameObject);
//				Debug.Log ("kill");
				Final ();
			}
		}

	}

	public void Final(){
		Application.LoadLevel ("Final");
	}

	void Cambio (){
		var exp = GetComponent<ParticleSystem> ();
		exp.Play();
	}

	void updateIndex(int tempAnatomia){
		mainCamera.GetComponent<Seguimiento> ().updateIndex(tempAnatomia-1);
	}
}