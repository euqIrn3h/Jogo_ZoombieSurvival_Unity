using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaArma : MonoBehaviour {

	public GameObject projetil;
	public GameObject capsula;
	public GameObject saidaDaCapsula;
	public GameObject pontaDaArma;
	public Text textoMunicao;
	private int quantidadeMunicao;


	// Use this for initialization
	void Start () {
		quantidadeMunicao = 15;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && quantidadeMunicao >0) {
			Instantiate(projetil, pontaDaArma.transform.position, pontaDaArma.transform.rotation);
			Instantiate(capsula, saidaDaCapsula.transform.position, saidaDaCapsula.transform.rotation);
			quantidadeMunicao--;
		}
		textoMunicao.text = quantidadeMunicao.ToString ();

		if (Input.GetKeyDown(KeyCode.R)) {
			Recarga ();
		}
	}

	private void Recarga(){
		quantidadeMunicao = 15;
	}
}