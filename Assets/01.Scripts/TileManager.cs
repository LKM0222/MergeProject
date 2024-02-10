using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//타일의 UI를 관리하는 스크립트
public class TileManager : MonoBehaviour
{
    Tile tile;
    Image sprite;
    // Start is called before the first frame update
    void Start()
    {
        tile = this.GetComponent<MergeTile>().tile;
        sprite = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
        //임시로 변경
        switch(tile.GetLevel()){
            case 1:
                sprite.color = Color.red;
            break;

            case 2:
                sprite.color = new Color(1f, 0.5f, 0f);
            break;

            case 3:
                sprite.color = Color.yellow;
            break;

            case 4:
                sprite.color = Color.green;
            break;

            case 5:
                sprite.color = Color.blue;
            break;

            case 6:
                sprite.color = new Color(0f, 0f, 0.5f);
            break;

            case 7:
                sprite.color = new Color(0.5f, 0f, 1f);
            break;
        }
    }
}
