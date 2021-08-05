using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using System.Collections;
using UnityEngine.UI;

public class DEMOmap : MonoBehaviour
{
	[SerializeField]
	AbstractMap _map;

	public GameObject Demo;

	[Geocode]
	Vector2d Userlocations;
	Vector2d _locations;

	[SerializeField]
	float _spawnScale = 100f;

	[SerializeField]
	GameObject[] Prefab;

	private GameObject Selected;
	private GameObject _spawnedObjects;
	private bool spawned = false;
	private AbstractLocationProvider _locationProvider = null;

	void Start()
	{
		string D = PlayerPrefs.GetString("Demo", "Off");
		if (D.Equals("On"))
		{
			Demo.SetActive(true);
		}
		else
		{
			Demo.SetActive(false);
		}

		if (null == _locationProvider)
		{
			_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
		}
	}

	public void HT()
	{
		spawn(Prefab[0]);
		Selected = Prefab[0];
	}
	public void S()
	{
		spawn(Prefab[1]);
		Selected = Prefab[1];
	}
	public void PGL()
	{
		spawn(Prefab[2]);
		Selected = Prefab[2];
	}
	public void PHL()
	{
		spawn(Prefab[3]);
		Selected = Prefab[3];
	}
	public void DA()
	{
		spawn(Prefab[4]);
		Selected = Prefab[4];
	}
	public void PA()
	{
		spawn(Prefab[5]);
		Selected = Prefab[5];
	}

	private void spawn(GameObject ToSpawn)
	{
		Destroy(_spawnedObjects);
		_locations = Userlocations + new Vector2d(0.000010f, 0);
		var instance = Instantiate(ToSpawn);
		instance.transform.localPosition = _map.GeoToWorldPosition(_locations, true);
		instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
		instance.transform.position = new Vector3(instance.transform.position.x, 0f, instance.transform.position.z);
		instance.transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
		_spawnedObjects = instance;
		spawned = true;

	}

	private void Update()
	{
		Location loc = _locationProvider.CurrentLocation;
		Userlocations = loc.LatitudeLongitude;

		if (spawned == true)
		{
			var spawnedObject = _spawnedObjects;
			var location = _locations;
			spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
			spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, 0f, spawnedObject.transform.position.z);
			spawnedObject.transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
		}


	}


	public Vector2d getLocation()
	{
		return _locations;
	}

	public GameObject getSpawned()

	{
		return Selected;
	}



}