// using System.Collections;
// using System.Collections.Generic;
// using Unity.Entities;
// using Unity.Mathematics;
// using Unity.Transforms;
// using UnityEngine;
//
// public class EcsRotate : MonoBehaviour
// {
//     public float speed;
// }
//
// public class RotatorSystem : ComponentSystem
// {
//     protected override void OnUpdate()
//     {
//         Entities.ForEach( (ref Transform transform) =>
//         {
//             transform.Rotate(0, 0, 0.1f, Space.Self);
//         });
//     }
// }
