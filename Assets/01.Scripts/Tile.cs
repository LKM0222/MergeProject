using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Tile
{
    [SerializeField] int level;
    [SerializeField] int tileType;

    public Tile(int _level, int _type){
        level = _level;
        tileType = _type;
    }

    public int GetLevel(){
        return level;
    }

    public int GetTileType(){
        return tileType;
    }

    public void SetLevel(int _level){
        level = _level;
    }

    public void SetType(int _type){
        tileType = _type;
    }

    public void UpLevel(){
        level += 1;
    }
}
