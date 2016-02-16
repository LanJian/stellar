using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	// game mesh
	public GameObject gObject;

	// ownerId if claimed
	private string ownerId = null;
	// unique planet id
	private string planetId;
	// planet type
	private string planetType;
	// planet mass
	private float mass;

	private float currentEnergy;
	private float maxEnergy;

	public bool ClaimOwnership(string playerId) {
		if (ownerId == null) {
			ownerId = playerId;
			return true;
		}
		return false;
	}
	
	public float Harvest() {
		// allows player to gather the resources from the planet
		return 0f;
	}

	public bool isDead() {
		// when energy is below 0, planet "dies"
		return false;
	}

	void Awake() {

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
