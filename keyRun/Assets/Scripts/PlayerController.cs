using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text keys;

	private GameObject ball;
	private float speed;
	private string axis1;
	private string axis2;
	private string axisTransition;
	private Rigidbody rb;
	private int count;
	private float moveVertical;
	private float moveHorizontal;

	void Start()
	{
		/*ball = gameObject;
		rb = GetComponent<Rigidbody> ();
		count = 0;
		speed = 0.0f;
		moveVertical = -2.5f;
		moveHorizontal = 5.0f;
		axis1 = "Horizontal";
		axis2 = "Vertical";
		axisTransition = "";*/
	}

	void Update ()
	{
		/*speed = 0.05f + Time.timeSinceLevelLoad / 100.0f;
		moveHorizontal = moveHorizontal + Input.GetAxis (axis1)*0.2f;
		moveVertical = moveVertical + Input.GetAxis (axis2)*speed;

		Vector3 movement = new Vector3 (moveHorizontal, rb.position.y, moveVertical);
		rb.MovePosition (movement);*/
	}

	void FixedUpdate()
	{
		
	}
		
}
