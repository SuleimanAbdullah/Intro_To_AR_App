using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField] private ExaminableManager examinableManager;
    [SerializeField] public float examinableScaleOffset = 1f;

    void Start()
    {
        examinableManager = GetComponent<ExaminableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestExamine()
    {
        examinableManager.PerformExamine(this);
    }

    public void RequestUnexamine()
    {
        examinableManager.PerformUnexamine();
    }
}
