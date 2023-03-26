using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject DropPrefab;

    private float coldown = 0;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            coldown -= Time.deltaTime;
            while (coldown < 0)
            {
                coldown += 0.01f;
                Instantiate(DropPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
