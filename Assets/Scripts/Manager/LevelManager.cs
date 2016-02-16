using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public struct Level {
        public int numResourcePlanet;
        public int numBlackholePlanet;
        public int numBasePlanet;

        public int maxFleetCount;
        public int startingResource;

        public int shipCost;

        public Level(int numResourcePlanet,
                int numBlackholePlanet,
                int numBasePlanet,
                int maxFleetCount,
                int startingResource,
                int shipCost) {

            this.numResourcePlanet = numResourcePlanet;
            this.numBlackholePlanet = numBlackholePlanet;
            this.numBasePlanet = numBasePlanet;
            this.maxFleetCount = maxFleetCount;
            this.startingResource = startingResource;
            this.shipCost = shipCost;
        }
	};

	Level level0 = new Level(
        numResourcePlanet: 3,
        numBlackholePlanet: 2,
        numBasePlanet: 3,
        maxFleetCount: 12,
        startingResource: 100,
        shipCost: 25
    );

	Level level1 = new Level(
        numResourcePlanet: 5,
        numBlackholePlanet: 3,
        numBasePlanet: 5,
        maxFleetCount: 25,
        startingResource: 200,
        shipCost: 25
    );

    Level level;

    void initLevel(string levelName) {
        if (levelName == "level00") {
            level = level0;
        } else if (levelName == "level01") {
            level = level1;
        }
    }

	// Use this for initialization
	void Start () {
        Scene activeScene = SceneManager.GetActiveScene();
        initLevel(activeScene.name);
	}

	// Update is called once per frame
	void Update () {

	}

    public Level getLevel() {
        return this.level;
    }
}
