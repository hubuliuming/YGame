/****************************************************
    文件：EnemyFactory.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.Pool;

public interface IEnemy: IInit
{
    /// <summary>
    /// 每次对象池中释放时候调用
    /// </summary>
    void InitData();
}
public class EnemyFactory : FactoryBase
{
    public static ObjectPool<GameObject> wildBoardPool = GetPool(EnemyName.WildBoar,Paths.WildBoar);

    public new static void Release(string name,GameObject go)
    {
        go.GetComponent<IEnemy>().InitData();
        pools[name].Release(go);
    }
}