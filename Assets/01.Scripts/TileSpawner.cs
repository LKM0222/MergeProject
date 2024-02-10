using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    #region Instance
    private static TileSpawner _instance;
    public static TileSpawner Instance{
        get{
            if(_instance == null){
                _instance = FindObjectOfType(typeof(TileSpawner)) as TileSpawner;
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform parent;
    public bool spawnFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() {
        if(spawnFlag){
            print("true");
            SpawnTile();
            spawnFlag = false;
        }
    }

    public void SpawnTile(){
        print("func");
        GameObject newTile = Instantiate(tilePrefab,this.transform.position, Quaternion.identity, parent);
        newTile.GetComponent<MergeTile>().tile.SetLevel(1);
    }

}
