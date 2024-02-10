using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeTile : MonoBehaviour
{   
    [SerializeField] GameObject cell;
    [SerializeField] GameObject targetTile;
    public Tile tile;

    [SerializeField] Vector3 startPos;


    private void OnMouseDown() {
        //처음위치 저장
        startPos = this.transform.position;
    }

    private void OnMouseDrag() {
        //타일이 마우스를 따라다니게 설정.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);
    }


    //스포너에 타일 생성하는 로직이 깔끔하지 않음...
    private void OnMouseUp() {
        //셀이 있는 경우
        if(cell != null){
            //타겟 타일이 있는 경우
            if(targetTile != null){
                //타겟 타일의 정보를 비교해야됨.
                if(CompareTile(targetTile.GetComponent<MergeTile>().tile, tile)){ //조건이 맞다면
                    this.transform.position = cell.transform.position; //위치를 옮기고
                    tile.UpLevel(); //타일의 레벨 1 증가
                    Destroy(targetTile); //타겟 타일 파괴
                    TileSpawner.Instance.spawnFlag = true; //타일 생성
                    
                }
                else{
                    this.transform.position = startPos; //조건과 맞지 않다면 처음 자리로
                }
            }
            else{ //타겟 타일이 없는경우엔 그냥 셀로만 이동
                this.transform.position = cell.transform.position;
                TileSpawner.Instance.spawnFlag = true;
            }
        }
        else{ //셀이 없는경우 이동할곳이 없음
            //처음 시작 자리로
            this.transform.position = startPos;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        //타일이 셀과 부딛혔을땐 타일의 셀 정보에 셀을 저장.
        if(other.tag == "Cell"){
            cell = other.gameObject;
        }
        else if(other.tag == "Tile"){
            targetTile = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //타일이 셀에서 나갔을땐 cell정보 파괴
        if(other.tag == "Cell"){
            cell = null;
        }
        else if(other.tag == "Tile"){
            targetTile = null;
        }
    }

    bool CompareTile(Tile tile1, Tile tile2){
        if(tile1.GetLevel() == tile2.GetLevel() && tile1.GetTileType() == tile2.GetTileType()){
            return true;
        }
        else{
            return false;
        }
    }

}
