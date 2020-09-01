using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public List<float> BoxSpawnPointsByXAxis;
    public Box BoxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnBoxes();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void spawnBoxes()
    {
        for (int i = 0; i < BoxSpawnPointsByXAxis.Count; i++)
        {
            Box box = Instantiate(BoxPrefab, position: new Vector3(BoxSpawnPointsByXAxis[i], -3.7f, 0f), rotation: Quaternion.identity);
        }
    }
}
