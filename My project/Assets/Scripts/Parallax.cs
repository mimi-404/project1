// // using UnityEngine;

// // public class ParallaxEffect : MonoBehaviour
// // {
// //     private float length, startPos;
// //     public GameObject cam;
// //     public float parallaxEffect;

// //     void Start()
// //     {
// //         startPos = transform.position.x;
// //         length = GetComponent<SpriteRenderer>().bounds.size.x;
// //     }

// //     void Update()
// //     {
// //         float temp = (cam.transform.position.x * (1 - parallaxEffect));
// //         float dist = (cam.transform.position.x * parallaxEffect);

// //         transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

// //         if (temp > startPos + length) startPos += length;
// //         else if (temp < startPos - length) startPos -= length;
// //     }
// // }
// using UnityEngine;

// public class ParallaxEffect : MonoBehaviour
// {
//     private float startPos;
//     private float length;
//     public GameObject cam; // Reference to the main camera
//     public float parallaxEffect; // Factor to control the parallax effect

//     void Start()
//     {
//         startPos = transform.position.x; // Initial position of the background
//         length = GetComponent<SpriteRenderer>().bounds.size.x; // Width of the background sprite
//     }

//     void LateUpdate()
//     {
//         float camPosX = cam.transform.position.x; // Current camera position on x-axis
//         float dist = camPosX * parallaxEffect; // Distance to move based on the parallax effect

//         // Update the position of the background (only along the x-axis)
//         transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

//         // Calculate temporary position to check looping
//         float temp = camPosX * (1 - parallaxEffect);

//         // Adjust the start position to create a looping effect
//         if (temp > startPos + length)
//         {
//             startPos += length;
//         }
//         else if (temp < startPos - length)
//         {
//             startPos -= length;
//         }
//     }
// }
// using UnityEngine;

// public class ParallaxEffect : MonoBehaviour
// {
//     private float startPos;
//     private float length;
//     public GameObject cam;
//     public float baseParallaxEffect = 0.5f;
//     private DriveCar driveCar;

//     void Start()
//     {
//         startPos = transform.position.x;
//         length = GetComponent<SpriteRenderer>().bounds.size.x;
//         driveCar = cam.GetComponent<Control>().target.GetComponent<DriveCar>();
//     }

//     void LateUpdate()
//     {
//         if (driveCar == null) return;

//         float carSpeed = driveCar.GetSpeed();
//         float dynamicParallaxEffect = Mathf.Lerp(baseParallaxEffect, baseParallaxEffect + carSpeed * 0.01f, Time.deltaTime);

//         float camPosX = cam.transform.position.x;
//         float dist = camPosX * dynamicParallaxEffect;

//         transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

//         float temp = camPosX * (1 - dynamicParallaxEffect);

//         if (temp > startPos + length)
//         {
//             startPos += length;
//         }
//         else if (temp < startPos - length)
//         {
//             startPos -= length;
//         }
//     }
// }
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component is missing on the parallax background object!");
            return;
        }

        startPos = transform.position.x;
        length = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}

