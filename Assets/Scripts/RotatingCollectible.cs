using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCollectible : MonoBehaviour
{

    public Material[] materials;
    private int currentMaterialIndex = 0;
    private int frameNumber = 0;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
         if (materials.Length > 0 && objectRenderer != null)
        {
            objectRenderer.material = materials[currentMaterialIndex];
        }

    }

    // Update is called once per frame
    void Update()
    {
        frameNumber += 1;
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        if (frameNumber % 60 == 0  ){
        currentMaterialIndex = Random.Range(0, materials.Length);
        objectRenderer.material = materials[currentMaterialIndex];
        }
       
    }
        public int GetCurrentMaterialIndex()
    {
        return currentMaterialIndex;
    }
}
