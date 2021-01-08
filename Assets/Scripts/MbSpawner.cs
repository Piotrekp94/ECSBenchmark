using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MbSpawner : MonoBehaviour
{
    public GameObject go;
    public int counter = 0;
    public Text text; 
    private void Update()
     {
         for (var i = 0; i < 20; i++)
         {
             var position = new Vector3(Random.Range(-160.0f, 160.0f), 0, Random.Range(-100.0f, 100.0f));
             Instantiate(go, position, Quaternion.identity);
             counter++;
         }

         text.text = counter.ToString();
     }
 }
