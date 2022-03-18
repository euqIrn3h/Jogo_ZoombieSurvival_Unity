using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

	public GameObject jogador;
	public float sensibilidade;
	public bool dadosBrutos;
	public bool inverteYAxis;
	private float rotacaoX, rotacaoY;
	private float rotacaoXV, rotacaoYV;
	private float rotacaoSuaveX, rotacaoSuaveY;
	private float coefSuavizacao;
	private bool toogleAim;
	private Vector3 aimPosicaoCamera;
	private Vector3 posicaoCamera;
	

	// Use this for initialization
	void Start () {
		coefSuavizacao = 0.1f;
		sensibilidade = 1;
		toogleAim = false;
		aimPosicaoCamera = new Vector3 (0.1f, 2.6f, 0.4f);
		posicaoCamera = new Vector3 (0f, 4f, -3.5f);
	}
	
	// Update is called once per frame
	void Update () {

		MovimentaCamera();
		if (Input.GetButtonDown ("Fire2")) {
			Aim ();
		}
			

	}

	private void MovimentaCamera()
	{
		rotacaoY += Input.GetAxis("Mouse X") * sensibilidade;
        rotacaoX =20;

		if(dadosBrutos){
            transform.rotation = Quaternion.Euler(rotacaoX, rotacaoY, 0);         
        }else{
            rotacaoSuaveX = Mathf.SmoothDamp(rotacaoSuaveX, rotacaoX, ref rotacaoXV, coefSuavizacao);
            rotacaoSuaveY = Mathf.SmoothDamp(rotacaoSuaveY, rotacaoY, ref rotacaoYV, coefSuavizacao); 
            transform.rotation = Quaternion.Euler(rotacaoSuaveX, rotacaoSuaveY, 0);        
        }
	}

	private int InverterYAxis()
	{
		if(inverteYAxis)
			return 1;
		return -1;
	}
		

	private void Aim()
	{
		if (toogleAim) 
		{
			jogador.GetComponent<ControlaJogador> ().SetVelocidade (8);	
			transform.localPosition = posicaoCamera;
			toogleAim = false;
			return;
		}

		jogador.GetComponent<ControlaJogador> ().SetVelocidade (4);
		transform.localPosition	= aimPosicaoCamera;
		toogleAim = true;
	}


}
