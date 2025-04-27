using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    public Transform examinableContainer;

    private Vector3 cachedPosition;
    private Quaternion cachedRotation;
    private Examinable currentExaminableObject;
    private Vector3 cachedScale;
    
    [SerializeField]private float rotateSpeed = 1f;
    
    private bool isExamining;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (isExamining == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    currentExaminableObject.transform.Rotate(touch.deltaPosition.x * rotateSpeed,
                        touch.deltaPosition.y * rotateSpeed,0);
                }
            }
        }
    }

    public void PerformExamine(Examinable examinable)
    {
        currentExaminableObject = examinable;
        cachedPosition = currentExaminableObject.transform.position;
        cachedRotation = currentExaminableObject.transform.rotation;
        cachedScale = currentExaminableObject.transform.localScale;
        
        currentExaminableObject.transform.position = examinableContainer.position;
        currentExaminableObject.transform.parent = examinableContainer;
        
        Vector3 offsetScale = cachedScale * examinable.examinableScaleOffset;
        currentExaminableObject.transform.localScale = offsetScale;
        isExamining = true;
    }

    public void PerformUnexamine()
    {
        currentExaminableObject.transform.position = cachedPosition;
        currentExaminableObject.transform.rotation = cachedRotation;
        currentExaminableObject.transform.localScale = cachedScale;
        currentExaminableObject.transform.parent = null;
        isExamining = false;
    }
}
