// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class NewBehaviourScript : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }
// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     [SerializeField] private Transform Layer_0; // Assign this in the inspector
//     [SerializeField] private Vector3 offset; // You can adjust this in the inspector

//     private void Update()
//     {
//         if (Layer_0 != null)
//         {
//             Vector3 newPosition = new Vector3(Layer_0.position.x + offset.x, transform.position.y, transform.position.z);
//             transform.position = newPosition;
//         }
//     }
// }