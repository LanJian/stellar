using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetManager : MonoBehaviour {
	public Quaternion DEFAULT_ROTATION = new Quaternion();
	public float LEVEL_MARGIN = 0;

	public GameObject spawnPlane;
	public GameObject pBlackhole;
	public GameObject pCity;
	public GameObject pBase;

	public LevelManager levelManager;
	// References to all planets
	public List<GameObject> planets;

	// Use this for initialization
	void Start () {
		generatePlanets();
		Debug.Log("SpawnPlane: " + spawnPlane.ToString());
	}

	// Update is called once per frame
	void Update () {
	}

	Vector3 getNextSpawnPoint() {
		GameObject spawnPlane = this.spawnPlane;
		float xRange = (spawnPlane.transform.localScale.x * spawnPlane.transform.localScale.x) / 2 - LEVEL_MARGIN;
		float yRange = (spawnPlane.transform.localScale.y * spawnPlane.transform.localScale.y) / 2 - LEVEL_MARGIN;
		float zRange = (spawnPlane.transform.localScale.z * spawnPlane.transform.localScale.z) / 2 - LEVEL_MARGIN;

		float randomX = Random.Range(-1 * xRange, xRange);
		// float randomY = Random.Range(spawnPlane.transform.position.y - spawnPlane.transform.localScale.y / 2, spawnPlane.transform.position.y + spawnPlane.transform.localScale.y / 2); 
		float randomZ = Random.Range(-1 * zRange, zRange);
		return new Vector3 (randomX, 0, randomZ);
	}

	void spawnPlanet(int count, GameObject planeObj) {
		// Spawn 
		for (int i = 0; i < count; i++) {
			Vector3 spawnPosition = this.getNextSpawnPoint();
			this.planets.Add(Instantiate (planeObj, spawnPosition, DEFAULT_ROTATION) as GameObject);
		}
	}

	void generatePlanets() {
		LevelManager.Level level = levelManager.getLevel();

		this.planets = new List<GameObject>();
		spawnPlanet(level.numResourcePlanet, pCity);
		spawnPlanet(level.numBasePlanet, pBase);
		spawnPlanet(level.numBlackholePlanet, pBlackhole);

		Debug.Log ("Instanted planets");
	}
}
