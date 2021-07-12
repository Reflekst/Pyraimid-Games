//using UnityEngine;
//using UnityEngine.AI;

//public class NavMeshBaker : MonoBehaviour
//{
//    public void Bake()
//    {
//        GameObject[] objects = GameObject.FindGameObjectsWithTag("Room");
//        NavMeshSurface[] surfaces = new NavMeshSurface[objects.Length];

//        for (int i = 0; i < objects.Length; i++)
//        {
//            surfaces[i] = objects[i].GetComponent<NavMeshSurface>();
//        }

//        for (int i = 0; i < surfaces.Length; i++)
//        {
//            surfaces[i].BuildNavMesh();
//        }
//    }

//}
