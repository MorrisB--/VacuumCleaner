using UnityEngine;
using System.Collections;

public class VacuumAgent : MonoBehaviour {

	public Transform[] Tiles; // Tiles in the scene
	public Transform CurrentTile; // Agent's current tile
	public Transform DirtTransform; // Transform component of a dirt object that is percived by the agent
	public float[] DistancesToTiles; // A float array that keeps the distances to all tiles
	public float MoveSpeed = 5f; // Agent's movement speed
	public bool isCleaning = false; // Flag value that indicates whether the agent is in the cleaning process or not

	void Start () {
		// Initialize agent target destination
		// your code here...

		// IDEAS
		/* 1) Move towards tile A
		 */
	}
	
	void Update () {

		CurrentTile = CurrentAgentTile (); // Find the curret tile

		if (!isCleaning) { // Currently there is no dirt, agent is moving between tiles
			/*
				If the agent is on tile A, it should move to tile B or vice versa
			// your code here...


			*/
		} else { // Agent notices some dirt and posistioning itself over the dirt.
			transform.Translate ((DirtTransform.position - transform.position) * Time.deltaTime, Space.World);
		}

		PerceptSequence (); // This function should print the percept sequence in this format : [A, Clean] or [A, Dirty]
	}

	Transform CurrentAgentTile() // This function returns the closest tile to the agent. The closest tile is considered as the current tile
	{
		for (int i = 0; i < Tiles.Length; i++) {
			// Calculate distances to tiles
			// your code here...


		}

		int closestTileIndex = 0;
		float closestDistance = DistancesToTiles [0];
		for (int i = 0; i < DistancesToTiles.Length; i++) {
			// find the index of the tile that is closest to the agent
			// your code here...

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

		DirtTransform = null; // since the dirt doesn't exist anymore, DirtTransform should become null.
		// End cleaning process
		// make the dirt disappear
		// your code here...

	}

	void PerceptSequence()
	{
		string cleaningState = "";
		// if agent noticed any dirt on the current tile, than the cleaningState should have a value "Dirty". Else, it should be "Clean".
		// your code here...


		Debug.Log ("[" + CurrentTile.name + ", " + cleaningState + "]");
	}
}
