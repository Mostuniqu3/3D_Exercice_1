using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float range;
    [SerializeField] private int numberOfPrefabs;
    List<GameObject> cubes = new List<GameObject>();

    private float lastRange = 0;
    private int lastNum = 0;

    List<GameObject> createShape() { 
        List<GameObject> arrayOfCubes = new List<GameObject>();
        float pi = (float) Mathf.PI;
        float x,y;
        float x0 = transform.position.x;
        float y0 = transform.position.y;
        float da = (float) 2.0 * pi / this.numberOfPrefabs;
        float a = 0;
        for (int i = 0; i < this.numberOfPrefabs ;i++) {
            a += da;
            x = x0 + this.range * Mathf.Cos(a);
            y = y0 + this.range * Mathf.Sin(a);
            Vector3 pos = new Vector3(x, y, 0);
            Quaternion rotation = Quaternion.Euler(new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f),Random.Range(-10f,10f)));
            arrayOfCubes.Add(Instantiate(cubePrefab, pos, rotation));
        }
        return arrayOfCubes;
    }

    void destroyCubes(List<GameObject> list) {
        if(list.Count == 0) {return;}
        foreach(GameObject cube in list){
            Destroy(cube);
        }
        this.cubes = new List<GameObject>();
    }
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(this.lastRange != this.range || this.lastNum != this.numberOfPrefabs){
            Debug.Log("Created new shape !");
            this.destroyCubes(this.cubes);
            this.cubes = createShape();
            this.lastRange = this.range;
            this.lastNum = this.numberOfPrefabs;
        }
    }
}
