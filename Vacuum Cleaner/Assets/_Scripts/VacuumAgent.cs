using UnityEngine;
using System.Collections;

public class VacuumAgent : MonoBehaviour {

	public Transform[] Tiles; // Tiles in the scene
	public Transform CurrentTile; // Agent's current tile
	public Transform DirtTransform; // Transform component of a dirt object that is percived by the agent
	public float[] DistancesToTiles; // A float array that keeps the distances to all tiles
	public float MoveSpeed = 5f; // Agent's movement speed
	public bool isCleaning = false; // Flag value that indicates whether the agent is in the cleaning process or not
	public int currentlyAt = 0;

	// DELETE THIS
	public bool a = true;

	void Start () {
		// Initialize agent target destination
		// your code here...
		DistancesToTiles = new float[Tiles.Length];
		// IDEAS
		/* 1) Move towards tile A
		 */

	}
	
	void Update () {

	/* UNTIL THE DISTANCE IS ALMOST ZERO DO NOT CHANGE DIRECTION */
		CurrentTile = CurrentAgentTile (); // Find the curret tile



		if (!isCleaning) { // Currently there is no dirt, agent is moving between tiles
			/*
			if (currentlyAt + 1 > Tiles.Length)
				currentlyAt = -1;
			transform.LookAt (Tiles [currentlyAt + 1].position);
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
*/

			if (currentlyAt == 0) {
				//transform.LookAt (Tiles [1].position);
				//transform.Translate ((Tiles [0].position - transform.position)/ DistancesToTiles[0] * MoveSpeed * Time.deltaTime);// += transform.forward * MoveSpeed * Time.deltaTime;
				transform.LookAt (Tiles [0].position);
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				if(DistancesToTiles[0] < 0.2)
				currentlyAt = 1;
			} else {
				//transform.LookAt (Tiles [0].position);
				//transform.Translate((Tiles[1].position - transform.position) / DistancesToTiles[1]* MoveSpeed * Time.deltaTime);
				transform.LookAt (Tiles [1].position);
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				if(DistancesToTiles[1]< 0.2)
				currentlyAt = 0;
			}

			/*
				//If the agent is on tile A, it should move to tile B or vice versa
			// your code here...


			*/
			/*
			if (a == true) {
				transform.LookAt (Tiles [1].position);
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				CurrentTile = Tiles [1];
				a = false;
			} else {
				transform.LookAt (Tiles [0].position);
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				CurrentTile = Tiles [0];
				a = true;}
*/

		} else { // Agent notices some dirt and posistioning itself over the dirt.
			transform.Translate ((DirtTransform.position - transform.position) * Time.deltaTime, Space.World);
		}

		PerceptSequence (); // This function should print the percept sequence in this format : [A, Clean] or [A, Dirty]
	}

	Transform CurrentAgentTile() // This function returns the closest tile to the agent. The closest tile is considered as the current tile
	{
		// Calculates the distance to all the tiles in the array
		for (int i = 0; i < Tiles.Length; i++) {
			// Calculate distances to tiles
			// your code here...

			DistancesToTiles [i] = Vector3.Distance (transform.position, Tiles [i].position);

		}

		int closestTileIndex = 0;
		float closestDistance = DistancesToTiles [0];

		// Finding the tile that is closest to the agent
		for (int i = 0; i < DistancesToTiles.Length; i++) {
			// find the index of the tile that is closest to the agent
			// your code here...

			// Compare the temporary clsoest distance to the distance to every tile and set the index to whereever the smaller number is
			if (closestDistance < DistancesToTiles [i]) {
				closestDistance = DistancesToTiles [i];
				closestTileIndex = i;
			}
		}

		return Tiles [closestTileIndex];
	}
		
	void OnTriggerEnter(Collider col) // This function detects collisions
	{
		if (col.tag == "Dirt") { // Agent noticed some dirt
			Debug.Log ("Agent: Dirt found at " + CurrentTile.name);
			StartCoroutine (CleanDirt (col.gameObject));
		} 

	}

	IEnumerator CleanDirt(GameObject dirtGameObject) // Cleaning starts
	{
		// Start cleaning process
		// your code here...

		yield return new WaitForSeconds (2.0f);
		dirtGameObject.SetActive(false); // deactivates the dirt game object
		// End cleaning process
		// make the dirt disappear
		// your code here...
		DirtTransform = null; // since the dirt doesn't exist anymore, DirtTransform should become null.

	}

	void PerceptSequence()
	{
		string cleaningState = "";
		// if agent noticed any dirt on the current tile, than the cleaningState should have a value "Dirty". Else, it should be "Clean".
		// your code here...


		Debug.Log ("[" + CurrentTile.name + ", " + cleaningState + "]");
	}
}
