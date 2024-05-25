using UnityEngine;

public class SetLayer_4Position : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        //Debug.Log("Script executed");
        currentPosition.y = -7f;


        transform.position = currentPosition;
    }
}
