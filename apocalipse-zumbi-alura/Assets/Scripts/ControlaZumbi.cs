using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour {

	public GameObject jogador;
	public float velocidade = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		float distancia = Vector3.Distance (transform.position, jogador.transform.position);

		if(distancia > 2.5){
			Vector3 direcao = jogador.transform.position - transform.position;
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao.normalized * velocidade * Time.deltaTime));

			Quaternion novaRotacao = Quaternion.LookRotation(direcao);
			GetComponent<Rigidbody>().MoveRotation(novaRotacao);
		}
	}
}
