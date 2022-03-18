using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCapsula : MonoBehaviour {

	private Vector3 velocidade;
	private Vector3 forca;
	private Rigidbody body;
	// Use this for initialization
	void Start () {
		forca = new Vector3 (0f, -300f, 0f);
		velocidade = transform.right * 6;
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		AceleracaoCapsula (0);
		body.velocity = velocidade;

		Invoke ("DestroiProjetil", 5f);

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (body.transform.position.y < 0.1f) {
			body.constraints = RigidbodyConstraints.FreezePositionY;
			Invoke ("DestroiColliderProjetil", 0.2f);
		}
	}

	private void DestroiColliderProjetil()
	{
		AceleracaoCapsula (1);
		Destroy(GetComponent<CapsuleCollider>());
	}

	private void AceleracaoCapsula(int param)
	{
		if (param == 0) {
			body.AddForce (forca);
		} else 
		{
			velocidade = Vector3.zero;
			body.velocity = velocidade;
			forca = transform.right * 10;
			body.AddForce (forca);

		}
	}

	private void DestroiProjetil()
	{
		Destroy (gameObject);
	}

}
