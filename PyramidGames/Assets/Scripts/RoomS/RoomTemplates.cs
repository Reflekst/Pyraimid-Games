using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomTemplates : MonoBehaviour
{
	
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public List<GameObject> rooms;

	public float waitTime;
	private int rand;
	private bool spawnedChestandDoor, spawnedDoor;
	public GameObject chest, door;


	void Update()
	{

		if (waitTime <= 0 && spawnedChestandDoor == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					rand = Random.Range(1, rooms.Count - 1);
					SpawnDoor(rand);
					Instantiate(chest, rooms[i].transform.position , Quaternion.identity);
					spawnedChestandDoor = true;
					//NavMeshBaker baker = GetComponent<NavMeshBaker>();
					//baker.Bake();
				}
			}
		}
		else
		{
			waitTime -= Time.deltaTime;
		}

		void SpawnDoor(int index)
		{
			if (rooms[index].name != "L(Clone)" && rooms[index].name != "RL(Clone)")
			{
				Instantiate(door, rooms[rand].transform.position + new Vector3(-5.6f, 0, 0), Quaternion.identity);
			}
			else
			{
				Instantiate(door, rooms[rand].transform.position + new Vector3(0, 0,-5.2f), Quaternion.Euler(0f, 90f, 0f));
			}
		}

		
	}
}