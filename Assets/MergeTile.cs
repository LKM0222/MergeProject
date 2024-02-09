using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeTile : MonoBehaviour
{   
    [SerializeField] GameObject cell;
    [SerializeField] Tile tile;

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

    private void OnMouseUp() {
        //셀 위에 있는 상태라면.
        if(cell != null){ 
            if(cell.GetComponent<MergeCell>().nowTile == null){ //셀에 타일이 없다면
                cell.GetComponent<MergeCell>().nowTile = this.gameObject; //현재 타일을 셀에 저장. 
                this.transform.position = cell.transform.position; //타일의 위치를 셀의 정 중앙에 맞춤.
            }
            else{// 셀에 타일이 있다면
                //셀에 있는 타일의 정보를 비교
                MergeTile cellTile = cell.GetComponent<MergeCell>().nowTile.GetComponent<MergeTile>();
                if(cellTile.tile.GetLevel() == tile.GetLevel() && cellTile.tile.GetTileType() == tile.GetTileType()){
                    //셀에 있는 타일과 현재 클릭한 타일의 레벨과 타입이 같으면 합치기 가능.
                    this.transform.position = cell.transform.position; //일단 현재 타일의 위치를 셀로 이동.
                    tile.UpLevel(); // 타일의 레벨 1 증가.
                    Destroy(cellTile.gameObject); //붙어있던 타일을 삭제.
                }
                else{ //둘 중, 하나라도 다르다면
                    this.transform.position = startPos; //처음위치로
                }
            }
        }
        else{
            // 셀 위에 없는 상태라면
            this.transform.position = startPos;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        //타일이 셀과 부딛혔을땐 타일의 셀 정보에 셀을 저장.
        if(other.tag == "Cell"){
            cell = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //타일이 셀에서 나갔을땐 cell정보 파괴
        if(other.tag == "Cell"){
            cell = null;
        }
    }

}
