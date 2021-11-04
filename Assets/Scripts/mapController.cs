using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapController : MonoBehaviour
{
    public int steps;
    public limitedMoveCube _limitedMoveCube;
    [SerializeField] private GameObject groundsPrefab;
    [SerializeField] private float x_Start;
    [SerializeField] private float y_Start;
    [SerializeField] private int row_Size;
    [SerializeField] private int column_Size;
    [Range(0, 2)] [SerializeField] private int x_Space_Dist;
    [Range(0, 2)] [SerializeField] private int y_Space_Dist;



    private GameObject createdObjects1, createdObjects2;

    [SerializeField] private GameObject barriersPrefab;
    [Range(4, 24)] [SerializeField] private int barrier_number;
    private List<Vector3> barriers = new List<Vector3>();
    private int x_barrier, z_barrier;

    private void Start()
    {
        _limitedMoveCube = GameObject.Find("limited-steps-red-cube").GetComponent<limitedMoveCube>();
    }
    public void createMap()
    {
        for (int i = 0; i < row_Size*column_Size;i++)
        {
            createdObjects1 = Instantiate(groundsPrefab, new Vector3(x_Start+(x_Space_Dist*(i%column_Size)), 0f, y_Start+(-y_Space_Dist*(i/column_Size))), Quaternion.identity );
            createdObjects1.transform.parent = GameObject.Find("Elements_of_Map").transform;
        }

    }
    public void deleteMap()
    {
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (var ground in grounds)
        {
            DestroyImmediate(ground);
        }
    }
    private void createBarriers()
    {
        createdObjects2 = GameObject.FindWithTag("Elements_Of_Map");

        while (barriers.Count < barrier_number)
        {
            x_barrier = Random.Range(0, row_Size);
            z_barrier = Random.Range(0, column_Size);

            if (!barriers.Contains(new Vector3(x_barrier, 0f, z_barrier)))
            {
                barriers.Add(new Vector3(x_barrier, 0f, z_barrier));
            }
        }
        for (int ii = 0; ii < barriers.Count; ii++)
        {
            GameObject addedObjects = Instantiate(barriersPrefab, barriers[ii], Quaternion.identity);
            addedObjects.transform.parent = GameObject.Find("Elements_of_Map").transform;
        }
        barriers.Clear();
    }

    public int SaveStepsFromGameObject(int a)
    {
        steps = a;
        a = _limitedMoveCube.stepValue;
        return a;
    }
}
