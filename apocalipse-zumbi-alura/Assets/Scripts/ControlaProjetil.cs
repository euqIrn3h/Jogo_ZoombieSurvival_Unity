using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaProjetil : MonoBehaviour {

	private int velocidade = 700;

	void Start()
	{ 
	}

	// Use this for initialization
	void FixedUpdate(){

		GetComponent<Rigidbody> ().velocity = transform.right * velocidade;
	
		//Invoke ("DestroyProjetil", 5); Destroioobjeto projetil em 5segundos
	}

	private void DestroyProjetil()
	{
		Destroy (gameObject);
	}


}



