using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private GameObject cameraa;
	private float currentCameraZ;
	private Vector3 offset;
	private float speedValue;
	public float speed;
	public Text countText;
	public GameObject[] keys;
	public GameObject keys1;
	public GameObject keys2;
	public GameObject displayedImage;
	public GameObject[] lefts;
	public GameObject[] rights;
	public GameObject[] middles;
	public GameObject[] triggers;
	public GameObject left1;
	public GameObject left2;
	public GameObject left3;
	public GameObject left4;
	public GameObject left5;
	public GameObject left6;
	public GameObject left7;
	public GameObject left8;
	public GameObject middle1;
	public GameObject middle2;
	public GameObject middle3;
	public GameObject middle4;
	public GameObject middle5;
	public GameObject middle6;
	public GameObject middle7;
	public GameObject middle8;
	public GameObject right1;
	public GameObject right2;
	public GameObject right3;
	public GameObject right4;
	public GameObject right5;
	public GameObject right6;
	public GameObject right7;
	public GameObject right8;
	public GameObject trigger1;
	public GameObject trigger2;
	public GameObject trigger3;
	public GameObject trigger4;
	public GameObject trigger5;
	public GameObject trigger6;
	public GameObject trigger7;
	public GameObject trigger8;

	private int randInt;
	private int randInt2;
	private int objectIndex;
	private int differenceBetweenChange;
	private int indexer;
	private string axis1;
	private string axis2;
	private string axisTransition;
	private Rigidbody rb;
	private float zPlacement;
	private int count;
	private float moveVertical;
	private float moveHorizontal;
	private bool gameOver;
	private float levelTime;
	private float lastDeathTime;
	private float xVal;
	private float yVal;
	private float zVal;

	// Use this for initialization
	void Start () {
		cameraa = gameObject;
		rb = player.GetComponent<Rigidbody> ();
		speedValue = Time.timeSinceLevelLoad / 100.0f;
		currentCameraZ += speedValue;
		SetCountText ();
		axis1 = "Horizontal";
		axis2 = "Vertical";
		axisTransition = "";
		count = 0;
		speed = 0.0f;
		moveVertical = -2.5f;
		moveHorizontal = 5.0f;
		indexer = 0;
		differenceBetweenChange = 10;
		gameOver = false;
		levelTime = 0.0f;
		lastDeathTime = 0.0f;
		objectIndex = 0;
		xVal = 0.0f;
		yVal = 0.0f;
		zVal = 0.0f;
	}

	void Update(){

		if (!gameOver) {
			levelTime = Time.timeSinceLevelLoad - lastDeathTime;
			speed = 0.3f + levelTime / 100.0f;
			moveHorizontal = moveHorizontal + Input.GetAxis (axis1) * 0.25f;
			moveVertical = moveVertical + Input.GetAxis (axis2) * speed;
		  	Vector3 movement = new Vector3 (moveHorizontal, rb.position.y, moveVertical);
			rb.MovePosition (movement);
			xVal = rb.position.x;
			yVal = rb.position.y;
			zVal = rb.position.z;
		} else {
			player.transform.position = new Vector3 (xVal, yVal, zVal);
		}
		if (rb.position.y < 0.35f) {
			countText.text = "Game Over " + "Score: " + count;
			cameraa.transform.position = Vector3.Lerp (cameraa.transform.position, new Vector3 (5.0f, 10.0f, -11.0f + currentCameraZ - 20.0f), 1.0f);
			gameOver = true;
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		
		if (!gameOver) {
			levelTime = Time.timeSinceLevelLoad - lastDeathTime;
			speedValue = levelTime / 100.0f;
			currentCameraZ += speedValue;
			cameraa.transform.position = new Vector3 (5.0f, 10.0f, -19.0f + currentCameraZ);
		}

	}	

	void OnTriggerEnter(Collider other)
	{
		count++;
		//if (count % 50 == 0) {
		//differenceBetweenChange += 6; 

		if ((count + 3) % differenceBetweenChange == 0) {
			
			player.GetComponent<Renderer> ().material.color = Color.green;
			SetImage ();
			Color curCol = keys [indexer].GetComponent<RawImage> ().color;
			curCol.a = 0.25f;
			keys [indexer].GetComponent<RawImage> ().color = curCol;
		} else if ((count + 2) % differenceBetweenChange == 0) {
			player.GetComponent<Renderer> ().material.color = Color.yellow;
			Color curCol = keys [indexer].GetComponent<RawImage> ().color;
			curCol.a = 0.5f;
			keys [indexer].GetComponent<RawImage> ().color = curCol;
		} else if ((count + 1) % differenceBetweenChange == 0) {
			player.GetComponent<Renderer> ().material.color = Color.red;
			Color curCol = keys [indexer].GetComponent<RawImage> ().color;
			curCol.a = 0.75f;
			keys [indexer].GetComponent<RawImage> ().color = curCol;
		} else if (count % differenceBetweenChange == 0) {
			player.GetComponent<Renderer> ().material.color = Color.magenta;
			Color curCol = keys [indexer].GetComponent<RawImage> ().color;
			curCol.a = 1.0f;
			keys [indexer].GetComponent<RawImage> ().color = curCol;
			axisTransition = axis1;
			axis1 = axis2;
			axis2 = axisTransition;
		}
		SetCountText ();

		if (objectIndex % 2 == 0) {
			randInt = Random.Range (1, 8);
		} else if(objectIndex % 2 == 1) {
			randInt = Random.Range (1, 5);
		}

		rights [objectIndex].SetActive (true);
		lefts [objectIndex].SetActive (true);
		middles [objectIndex].SetActive (true);
		rights [objectIndex].transform.Translate (new Vector3 (0.0f, 0.0f, 110.0f));
		lefts [objectIndex].transform.Translate (new Vector3 (0.0f, 0.0f, 110.0f));
		middles [objectIndex].transform.Translate (new Vector3 (0.0f, 0.0f, 110.0f));
		triggers [objectIndex].transform.Translate (new Vector3 (0.0f, 0.0f, 110.0f));
		if (randInt == 1) {
			lefts [objectIndex].SetActive (true);
			rights [objectIndex].SetActive (true);
			middles [objectIndex].SetActive (true);
		} else if (randInt == 2) {
			lefts [objectIndex].SetActive (false);
			rights [objectIndex].SetActive (true);
			middles [objectIndex].SetActive (true);
		} else if (randInt == 3) {
			rights [objectIndex].SetActive (true);
			lefts [objectIndex].SetActive (false);
			middles [objectIndex].SetActive (true);
		} else if (randInt == 4) {
			rights [objectIndex].SetActive (false);
			lefts [objectIndex].SetActive (false);
			middles [objectIndex].SetActive (true);
		} else if (randInt == 5) {
			rights [objectIndex].SetActive (true);
			lefts [objectIndex].SetActive (false);
			middles [objectIndex].SetActive (false);
		} else if (randInt == 6) {
			rights [objectIndex].SetActive (false);
			lefts [objectIndex].SetActive (false);
			middles [objectIndex].SetActive (true);
		} else if (randInt == 7) {
			rights [objectIndex].SetActive (true);
			lefts [objectIndex].SetActive (true);
			middles [objectIndex].SetActive (false);
		} else {
			lefts [objectIndex].SetActive (true);
			rights [objectIndex].SetActive (true);
			middles [objectIndex].SetActive (true);
		}	

		objectIndex = (objectIndex + 1) % (rights.Length);
	




		/*if (other.gameObject == trigger1) {
			right1.SetActive (true);
			left1.SetActive (true);
			middle1.SetActive (true);
			right1.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left1.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle1.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger1.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt == 2) {
				left1.SetActive (false);
				right1.SetActive (true);
				middle1.SetActive (true);
			} else if (randInt == 3) {
				right1.SetActive (false);
				left1.SetActive (false);
				middle1.SetActive (true);
			} else if (randInt == 4) {
				right1.SetActive (false);
				left1.SetActive (true);
				middle1.SetActive (false);
			} else if (randInt == 5) {
				right1.SetActive (true);
				left1.SetActive (false);
				middle1.SetActive (true);
			} else if (randInt == 6) {
				right1.SetActive (true);
				left1.SetActive (false);
				middle1.SetActive (false);
			}

		} else if (other.gameObject == trigger2) {
			right2.SetActive (true);
			left2.SetActive (true);
			middle2.SetActive (true);
			right2.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left2.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle2.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger2.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt2 == 2) {
				left2.SetActive (false);
				right2.SetActive (true);
				middle2.SetActive (true);
			} else if (randInt2 == 3) {
				right2.SetActive (true);
				left2.SetActive (false);
				middle2.SetActive (true);
			}
		} else if (other.gameObject == trigger3) {
			right3.SetActive (true);
			left3.SetActive (true);
			middle3.SetActive (true);
			right3.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left3.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle3.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger3.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt == 2) {
				left3.SetActive (false);
				right3.SetActive (true);
				middle3.SetActive (true);
			} else if (randInt == 3) {
				right3.SetActive (false);
				left3.SetActive (false);
				middle3.SetActive (true);
			} else if (randInt == 4) {
				right3.SetActive (false);
				left3.SetActive (true);
				middle3.SetActive (false);
			} else if (randInt == 5) {
				right3.SetActive (true);
				left3.SetActive (false);
				middle3.SetActive (true);
			} else if (randInt == 6) {
				right3.SetActive (true);
				left3.SetActive (false);
				middle3.SetActive (false);
			}
		} else if (other.gameObject == trigger4) {
			right4.SetActive (true);
			left4.SetActive (true);
			middle4.SetActive (true);
			right4.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left4.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle4.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger4.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt2 == 2) {
				left4.SetActive (false);
				right4.SetActive (true);
				middle4.SetActive (true);
			} else if (randInt2 == 3) {
				right4.SetActive (true);
				left4.SetActive (false);
				middle4.SetActive (true);
			}
		} else if (other.gameObject == trigger5) {
			right5.SetActive (true);
			left5.SetActive (true);
			middle5.SetActive (true);
			right5.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left5.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle5.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger5.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt == 2) {
				left5.SetActive (false);
				right5.SetActive (true);
				middle5.SetActive (true);
			} else if (randInt == 3) {
				right5.SetActive (false);
				left5.SetActive (false);
				middle5.SetActive (true);
			} else if (randInt == 4) {
				right5.SetActive (false);
				left5.SetActive (true);
				middle5.SetActive (false);
			} else if (randInt == 5) {
				right5.SetActive (true);
				left5.SetActive (false);
				middle5.SetActive (true);
			} else if (randInt == 6) {
				right5.SetActive (true);
				left5.SetActive (false);
				middle5.SetActive (false);
			}
		} else if (other.gameObject == trigger6) {
			right6.SetActive (true);
			left6.SetActive (true);
			middle6.SetActive (true);
			right6.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left6.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle6.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger6.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt2 == 2) {
				left6.SetActive (false);
				right6.SetActive (true);
				middle6.SetActive (true);
			} else if (randInt2 == 3) {
				right6.SetActive (true);
				left6.SetActive (false);
				middle6.SetActive (true);
			}
		} else if (other.gameObject == trigger7) {
			right7.SetActive (true);
			left7.SetActive (true);
			middle7.SetActive (true);
			right7.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left7.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle7.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger7.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt == 2) {
				left7.SetActive (false);
				right7.SetActive (true);
				middle7.SetActive (true);
			} else if (randInt == 3) {
				right7.SetActive (false);
				left7.SetActive (false);
				middle7.SetActive (true);
			} else if (randInt == 4) {
				right7.SetActive (false);
				left7.SetActive (true);
				middle7.SetActive (false);
			} else if (randInt == 5) {
				right7.SetActive (true);
				left7.SetActive (false);
				middle7.SetActive (true);
			} else if (randInt == 6) {
				right7.SetActive (true);
				left7.SetActive (false);
				middle7.SetActive (false);
			}
		} else if (other.gameObject == trigger8) {
			right8.SetActive (true);
			left8.SetActive (true);
			middle8.SetActive (true);
			right8.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			left8.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			middle8.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			trigger8.transform.Translate (new Vector3 (0.0f, 0.0f, 80.0f));
			if (randInt2 == 2) {
				left8.SetActive (false);
				right8.SetActive (true);
				middle8.SetActive (true);
			} else if (randInt2 == 3) {
				right8.SetActive (true);
				left8.SetActive (false);
				middle8.SetActive (true);
			}
		}*/
	}

	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
	}

	void SetImage()
	{
		keys [indexer].SetActive (false);
		indexer = (indexer + 1) % keys.Length;
		keys [indexer].SetActive (true);
	}

	void OnGUI() {
		if (GUILayout.Button("Restart")) {
			SceneManager.LoadScene ("JamBasis");
			/*
			lastDeathTime = Time.timeSinceLevelLoad;
			speedValue = 0;
			currentCameraZ += 0;
			SetCountText ();
			axis1 = "Horizontal";
			axis2 = "Vertical";
			axisTransition = "";
			count = 0;
			speed = 0.0f;
			moveVertical = -2.5f;
			moveHorizontal = 5.0f;
			indexer = 0;
			differenceBetweenChange = 10;


			player.transform.position = (new Vector3 (5.0f, 0.51f, -2.5f));
			transform.position = (new Vector3(5.0f,10.0f,-25.0f));
			//cameraa.transform.Rotate(new Vector3 (11.0f, 0.0f, 0.0f));

			right1.SetActive (true);
			left1.SetActive (true);
			middle1.SetActive (true);

			right2.SetActive (true);
			left2.SetActive (true);
			middle2.SetActive (true);

			right3.SetActive (true);
			left3.SetActive (true);
			middle3.SetActive (true);

			right4.SetActive (true);
			left4.SetActive (true);
			middle4.SetActive (true);

			right5.SetActive (true);
			left5.SetActive (true);
			middle5.SetActive (true);

			right6.SetActive (true);
			left6.SetActive (true);
			middle6.SetActive (true);

			right7.SetActive (true);
			left7.SetActive (true);
			middle7.SetActive (true);

			right8.SetActive (true);
			left8.SetActive (true);
			middle8.SetActive (true);

			right1.transform.position = (new Vector3 (15.0f, 0.0f, 0.0f));
			left1.transform.position = (new Vector3 (-5.0f, 0.0f, 0.0f));
			middle1.transform.position = (new Vector3 (5.0f, 0.0f, 0.0f));
			trigger1.transform.position = (new Vector3 (5.0f, 7.5f, 10.0f));

			right2.transform.position = (new Vector3 (15.0f, 0.0f, 10.0f));
			left2.transform.position = (new Vector3 (-5.0f, 0.0f, 10.0f));
			middle2.transform.position = (new Vector3 (5.0f, 0.0f, 10.0f));
			trigger2.transform.position = (new Vector3 (5.0f, 7.5f, 20.0f));

			right3.transform.position = (new Vector3 (15.0f, 0.0f, 20.0f));
			left3.transform.position = (new Vector3 (-5.0f, 0.0f, 20.0f));
			middle3.transform.position = (new Vector3 (5.0f, 0.0f, 20.0f));
			trigger3.transform.position = (new Vector3 (5.0f, 7.5f, 30.0f));

			right4.transform.position = (new Vector3 (15.0f, 0.0f, 30.0f));
			left4.transform.position = (new Vector3 (-5.0f, 0.0f, 30.0f));
			middle4.transform.position = (new Vector3 (5.0f, 0.0f, 30.0f));
			trigger4.transform.position = (new Vector3 (5.0f, 7.5f, 40.0f));

			right5.transform.position = (new Vector3 (15.0f, 0.0f, 40.0f));
			left5.transform.position = (new Vector3 (-5.0f, 0.0f, 40.0f));
			middle5.transform.position = (new Vector3 (5.0f, 0.0f, 40.0f));
			trigger5.transform.position = (new Vector3 (5.0f, 7.5f, 50.0f));

			right6.transform.position = (new Vector3 (15.0f, 0.0f, 50.0f));
			left6.transform.position = (new Vector3 (-5.0f, 0.0f, 50.0f));
			middle6.transform.position = (new Vector3 (5.0f, 0.0f, 50.0f));
			trigger6.transform.position = (new Vector3 (5.0f, 7.5f, 60.0f));

			right7.transform.position = (new Vector3 (15.0f, 0.0f, 60.0f));
			left7.transform.position = (new Vector3 (-5.0f, 0.0f, 60.0f));
			middle7.transform.position = (new Vector3 (5.0f, 0.0f, 60.0f));
			trigger7.transform.position = (new Vector3 (5.0f, 7.5f, 70.0f));

			right8.transform.position = (new Vector3 (15.0f, 0.0f, 70.0f));
			left8.transform.position = (new Vector3 (-5.0f, 0.0f, 70.0f));
			middle8.transform.position = (new Vector3 (5.0f, 0.0f, 70.0f));
			trigger8.transform.position = (new Vector3 (5.0f, 7.5f, 80.0f));
			gameOver = false;*/
		}
	}
}

