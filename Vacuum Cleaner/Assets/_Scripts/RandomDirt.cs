using UnityEngine;
using System.Collections;

public class RandomDirt : MonoBehaviour {

	public GameObject Dirt;
	public float DirtGenerateFreq = 5.0f;
	public bool ReadyToGenerateDirt = false;
	// Use this for initialization
	void Start () {
		Invoke ("Activate", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		GenerateDirt ();
	}

	void Activate()
	{
		ReadyToGenerateDirt = true;
	}

	void GenerateDirt()
	{
		if (ReadyToGenerateDirt) {
			StartCoroutine (WaitToGenerate ());
			Instantiate (Dirt, new Vector3 (Random.Range (-1.5f, 6.5f), -1, Random.Range (-1.2f, -4.7f)), Quaternion.identity);
		}
	}

	IEnumerator WaitToGenerate()
	{
		ReadyToGenerateDirt = false;
		yield return new WaitForSeconds (DirtGenerateFreq);
		ReadyToGenerateDirt = true;
	}
}
