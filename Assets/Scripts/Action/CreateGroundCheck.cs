using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGroundCheck : MonoBehaviour
{
    [SerializeField] private GameObject groundCheckPrefab;
    [SerializeField] private int rowNumber;
    [SerializeField] private int colNumber;

    private void Start()
    {
        for (int i = 0 - rowNumber / 2; i < rowNumber - rowNumber / 2; i++)
        {
            for (int j = 0 - colNumber / 2; j < colNumber - rowNumber / 2; j++)
            {
                var obj = Instantiate(groundCheckPrefab, transform);
                Vector3 pos = new Vector3(i, transform.position.y, j);
                obj.transform.position = pos;
            }
        }
    }
}
