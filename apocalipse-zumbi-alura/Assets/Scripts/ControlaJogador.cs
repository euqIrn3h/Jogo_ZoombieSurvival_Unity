using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControlaJogador : MonoBehaviour {

	private float velocidade;
	private float rotacaoX;
	private Rigidbody body;
	private Vector3 novaVelocidade;

	void  Start(){

		velocidade = 8;
		body = GetComponent<Rigidbody> ();
		novaVelocidade = new Vector3 ();
		novaVelocidade.y = 0;
		
	}


	// Update is called once per frame
	void Update () {
		rotacaoX = Camera.main.transform.eulerAngles.y;
		transform.rotation = Quaternion.Euler(0, rotacaoX, 0);

		novaVelocidade = (Input.GetAxis ("Horizontal") * transform.right * velocidade) + (Input.GetAxis ("Vertical") * transform.forward * velocidade);
		body.velocity = novaVelocidade;

		if (body.velocity.magnitude != 0)
			GetComponent<Animator> ().SetBool ("movendo", true);
		else
			GetComponent<Animator> ().SetBool ("movendo", false);

	}

	public float GetVelocidade()
	{
		return velocidade;
	}

	public void SetVelocidade(float novaVelocidade)
	{
		velocidade = novaVelocidade;
	}

}
