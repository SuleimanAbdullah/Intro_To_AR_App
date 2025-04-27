using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    public string germColorName;

    [SerializeField] private Material targetMaterial;
    
    private Color originalEmissionColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        originalEmissionColor = targetMaterial.GetColor("_EmissionColor");
        
        targetMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void ChangeEmissionColor(bool isEmitting)
    {
        if (isEmitting == true)
        {
            targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
        }
        else
        {
            targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }
}
