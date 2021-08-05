
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.Location;
	using Mapbox.Utils;
	using Mapbox.Unity.Utilities;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using Unity.Notifications.Android;

public class LocationStatus : MonoBehaviour
	{
		public GameObject loading;
		public Button camera;
		public AbstractMap Map;
		public GameObject Items;
		public GameObject Demo;
		public GameObject notify;

		[SerializeField]
		Text _statusText;
	    [SerializeField]
	     Text Noti;

	    [Geocode]
		Vector2d Userlocations;
		[Geocode]
		Vector2d[] Itemslocations;

		private AbstractLocationProvider _locationProvider = null;
		static public GameObject item;

		void Start()
		{
			Noti.text = " no character nearby!";

			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}

			var c = new AndroidNotificationChannel()
			{
				Id = "channel_id",
				Name = "Default Channel",
				Importance = Importance.High,
				Description = "Generic notifications",
			};
			AndroidNotificationCenter.RegisterNotificationChannel(c);

			sentNoty("Using Location", "This app use location for gameplay!");

		}


		void Update()
		{
			Location currLoc = _locationProvider.CurrentLocation;

			if (currLoc.IsLocationServiceInitializing)
			{
				_statusText.text = "location services are initializing";
			}
			else
			{
				if (!currLoc.IsLocationServiceEnabled)
				{
					_statusText.text = "location services not enabled";
					
				}
				else
				{
					if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
					{
						_statusText.text = "Waiting for location ....";
					}
					else
					{
						_statusText.text = string.Format("{0}", currLoc.LatitudeLongitude);
						 loading.SetActive(false);
						 distance(currLoc.LatitudeLongitude);

				}
				}


			}

		}

	public void distance( Vector2d Userloc)
	{
		Userlocations = Userloc;
		GameObject[] prefab;
		string D = PlayerPrefs.GetString("Demo", "Off");
		if (D.Equals("On"))
		{
			Itemslocations = NewLocation(Items.GetComponent<SpawnOnMap>().getlocations());
			prefab = NewObject(Items.GetComponent<SpawnOnMap>().getPrefab());
		}
		else
		{
			Itemslocations = Items.GetComponent<SpawnOnMap>().getlocations();
			prefab = Items.GetComponent<SpawnOnMap>().getPrefab();
		}
		
		List<bool> flagNear = new List<bool>();
		List<bool> flagReach = new List<bool>();
		Debug.Log("Loc user : " + string.Format("{0}", Userloc));
		int count = Itemslocations.Length;

		for (int i = 0; i < count; i++)
		{
			Vector3 from = Map.GeoToWorldPosition(Userlocations, false);
			Vector3 to= Map.GeoToWorldPosition(Itemslocations[i], false);
			float distance= new Vector2(to.x - from.x, to.z - from.z).magnitude / Map.WorldRelativeScale;
			Debug.Log("Distance : " + distance.ToString());
			bool flag1 = false; bool flag2 = false;

			if (distance <= 300.0)
			{
				Debug.Log("Near ");
				flag1 = true; 
			}
			else
			{
				flag1 = false;
			}
			flagNear.Add(flag1);

			if (distance <= 3)
			{
				flag2 = true;
				//camera.interactable = true;
				//item = prefab[i];
			}
			else
			{
				flag2 = false;
				//camera.interactable = false;
			}
			flagReach.Add(flag2);
		}
		bool flagnoti = false;
		for (int i = 0; i < flagNear.Count; i++)
		{
			if (flagNear[i])
			{
				notify.SetActive(true);
				Noti.text = "There are character nearby";
				flagnoti = true;
				break;
			}
			else
			{
				notify.SetActive(false);
				Noti.text = "";
			}
		}

		for (int i = 0; i < flagReach.Count; i++)
		{
			if (flagReach[i])
			{
				camera.interactable = true;
				item = prefab[i];
				break;
			}
			else
			{
				camera.interactable = false;
			}
		}


	}

	public void sentNoty(string Title,string Text)
	{
		var notification = new AndroidNotification();
		notification.Title = Title;
		notification.Text = Text;
		notification.FireTime = System.DateTime.Now;

		AndroidNotificationCenter.SendNotification(notification, "channel_id");
	}

	private Vector2d[] NewLocation(Vector2d[] current)
	{
		Vector2d[] Newloc = new Vector2d[current.Length+1];
		int i = 0;
		while( i < current.Length)
		{
			Newloc[i] = current[i];
			i++;
		}
		Newloc[i] = Demo.GetComponent<DEMOmap>().getLocation();

		return Newloc;
	}

	private GameObject[] NewObject(GameObject[] current)
	{
		GameObject[] NewObj = new GameObject[current.Length + 1];
		int i = 0;
		while(i < current.Length)
		{
			NewObj[i] = current[i];
			i++;
		}
		NewObj[i] = Demo.GetComponent<DEMOmap>().getSpawned();
		return NewObj;
	}





}
