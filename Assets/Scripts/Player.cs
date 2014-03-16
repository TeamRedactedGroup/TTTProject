using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Adding this comment as a new thing to test github update

	#region Variables
	public bool pNum; //Tracks whose turn it is
	public GameObject X_Piece;
	public GameObject O_Piece;
	public GameObject gameBoardSpace;
	public Transform myTransform;
	#endregion

	#region Functions
	// Use this for initialization
	void Start () {
		pNum = true; //sets player order
		//code to highlight player one's name on the UI
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))
		{
			//get object the player clicked on
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 10))
			{
				myTransform = hit.transform.gameObject.transform;
				gameBoardSpace = hit.transform.gameObject;
				//Debug.Log(hit.transform.gameObject.name);
			}

			//Gets the location on the board that the piece 
			Vector3 boardLocation = new Vector3(myTransform.position.x, myTransform.position.y + 0.1f, myTransform.position.z);

			//check if object is vacant
			//if vacant, place piece of that player
			if(pNum && gameBoardSpace.tag != "Occupied")
			{
				Instantiate(O_Piece, boardLocation, Quaternion.identity);
				pNum = false;
				gameBoardSpace.tag = "Occupied";
			}
			else if(!pNum && gameBoardSpace.tag != "Occupied")
			{
				Instantiate(X_Piece, boardLocation, Quaternion.identity);
				pNum = true;
				gameBoardSpace.tag = "Occupied";
			}
		}
	}
	#endregion
}
