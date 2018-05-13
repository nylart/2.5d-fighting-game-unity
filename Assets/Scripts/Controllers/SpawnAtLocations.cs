using UnityEngine;
using System.Collections;

public class SpawnAtLocations : MonoBehaviour
{

	[Tooltip("The Prefab to instantiate at the locations")]
	public GameObject[]
		prefabsToSpawn;
	[Tooltip("If true & more than one prefab, spawns them randomly. If false, spawns in order")]
	public bool
		randomSpawn = true;
	[Tooltip("The transforms of locations you want to spawn the prefabs")]
	public Transform[]
		locations;
	[Tooltip("if true & more than one location, chooses locations randomly.  If false, spawns in order")]
	public bool
		randomLocation = true;
	private bool isSpawnerActive = true;

	// Set this in your GameController Script, so it only spawns while playing the game
	public bool SpawnerActive {
		get { return isSpawnerActive; }
		set { isSpawnerActive = value; }
	}

	[Tooltip("Minimum Spawn Time")]
	public float
		minSpawnTime = 1.0f;
	[Tooltip("Maximum Spawn Time")]
	public float
		maxSpawnTime = 1.0f;
	private int spawnIndex;
	private int locIndex;
	private float timer;

	void Start( )
	{
		if ( prefabsToSpawn.Length == 0 ) {
			Error.DisabledGameObject( this.gameObject.name, "prefabsToSpawn size is zero!" );
		}
		if ( locations.Length == 0 ) {
			Error.DisabledGameObject( this.gameObject.name, "locations size is zero!" );
		}

		spawnIndex = prefabsToSpawn.Length;
		locIndex = locations.Length;
		timer = Random.Range( minSpawnTime, maxSpawnTime );
	}

	void Update( )
	{
		if ( isSpawnerActive ) {
			if ( timer < 0 ) {
				spawn( );
				timer = Random.Range( minSpawnTime, maxSpawnTime );
			} else {
				timer -= Time.deltaTime;
			}
		}
	}

	// Spawns the Prefabs
	void spawn( )
	{

		if ( randomSpawn && prefabsToSpawn.Length > 1 ) {
			spawnIndex = Random.Range( 0, prefabsToSpawn.Length );
		} else {
			spawnIndex++;
			if ( spawnIndex >= prefabsToSpawn.Length ) {
				spawnIndex = 0;
			}
		}
		if ( randomLocation && locations.Length > 1 ) {
			locIndex = Random.Range( 0, locations.Length );
		} else {
			locIndex++;
			if ( locIndex >= locations.Length ) {
				locIndex = 0;
			}
		}

		Instantiate( prefabsToSpawn[spawnIndex], locations[locIndex].position, locations[locIndex].rotation );

	}
}
