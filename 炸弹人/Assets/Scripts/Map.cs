/****************************************************
    文件：Map.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public enum AreaType
{
    None,
    Walk,
    SuperWalk
}
public class Map : MonoBehaviour
{
    private int row = 7;
    private int column = 13;
    private AreaType[,] maps;
    
    private void Start()
    {
        maps = new AreaType[row, column];

        #region Level 1

        maps[0, 3] = AreaType.Walk;
        maps[0, 4] = AreaType.Walk;
        maps[0, 7] = AreaType.Walk;
        maps[0, 9] = AreaType.Walk;
        maps[0, 10] = AreaType.Walk;
        
        maps[1, 1] = AreaType.SuperWalk;
        maps[1, 3] = AreaType.SuperWalk;
        maps[1, 5] = AreaType.SuperWalk;
        maps[1, 7] = AreaType.SuperWalk;
        maps[1, 9] = AreaType.SuperWalk;
        maps[1, 11] = AreaType.SuperWalk;       
        
        maps[2,6] = AreaType.Walk;
        maps[2,12] = AreaType.Walk;
        
        maps[3,1] = AreaType.SuperWalk;
        maps[3,3] = AreaType.SuperWalk;
        maps[3,4] = AreaType.Walk;
        maps[3,5] = AreaType.SuperWalk;
        maps[3,6] = AreaType.Walk;
        maps[3,7] = AreaType.SuperWalk;
        maps[3,9] = AreaType.SuperWalk;
        maps[3,11] = AreaType.SuperWalk;

        maps[4,0] = AreaType.Walk;
        maps[4,1] = AreaType.Walk;
        maps[4,2] = AreaType.Walk;
        maps[4,5] = AreaType.Walk;
        maps[4,7] = AreaType.Walk;
        maps[4,8] = AreaType.Walk;
        
        
        maps[5, 1] = AreaType.SuperWalk;
        maps[5, 3] = AreaType.SuperWalk;
        maps[5, 5] = AreaType.SuperWalk;
        maps[5, 7] = AreaType.SuperWalk;
        maps[5, 9] = AreaType.SuperWalk;
        maps[5, 11] = AreaType.SuperWalk;

        maps[6, 0] = AreaType.Walk;
        maps[6, 1] = AreaType.Walk;
        maps[6, 7] = AreaType.Walk;
        
        #endregion

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                CreateMap(i,j,maps[i,j]);
            }
        }
    }

    private void CreateMap(int x,int y,AreaType areaType)
    {

        switch (areaType)
        {
            case AreaType.None:
                break;
            case AreaType.Walk:
                var walkPreb = Resources.Load<GameObject>("Prefabs/Walk");
                var walk = Instantiate(walkPreb, transform);
                walk.GetComponent<RectTransform>().anchoredPosition = new Vector2(y *100 + 50,   -x *100 -50);
                break;
            case AreaType.SuperWalk:
                var superWalkPreb = Resources.Load<GameObject>("Prefabs/Superwalk");
                var superWalk = Instantiate(superWalkPreb, transform);
                superWalk.GetComponent<RectTransform>().anchoredPosition = new Vector2(y *100 + 50,   -x *100 -50);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(areaType), areaType, null);
        }
       
    }
}