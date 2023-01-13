/****************************************************
    文件：EditorTest.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/


using System.Collections.Generic;
using Code_01.Enemy;
using Code_01.Mode;
using YFramework.Kit.Utility;

namespace Code_01.Editor
{
#if UNITY_EDITOR
    public class EditorTest  
    {
        [UnityEditor.MenuItem("Tools/重写写入ItemJson")]
        private static void WriteItemJson()
        {
            Dictionary<string,ItemBase.ItemData> datas = new Dictionary<string,ItemBase.ItemData>
            {
                {Msg.ItemName.馒头,new ItemBase.ItemData()
                {
                    changeAttack = 0,
                    changeCoin = 0,
                    changeDefence = 0,
                    changeHp = 5,
                    changePower = 20,
                    changeSpeed = 0
                }},
                {Msg.ItemName.活力苹果,new ItemBase.ItemData()
                {
                    changeAttack = 0,
                    changeCoin = 0,
                    changeDefence = 0,
                    changeHp = 10,
                    changePower = 10,
                    changeSpeed = 0
                }}
            };
            YJsonUtility.WriteToJson(datas,Msg.Paths.Config.RecoverItem);
        }
        
        [UnityEditor.MenuItem("Tools/重写写入EnemyJson")]
        private static void WriteEnemyJson()
        {
            Dictionary<string, EnemyBase.EnemyData> datas = new Dictionary<string, EnemyBase.EnemyData>()
            {
                {
                    Msg.EnemyName.野猪, new EnemyBase.EnemyData()
                    {
                        HP = 100,
                        Attack = 10,
                        Defence = 3,
                        Speed = 5,
                        CostPower = 10,
                        award = new EnemyBase.EnemyData.Award()
                        {
                            Exp = 10,
                            Coin = 20,
                            GoodsName = Msg.ItemName.小块肉
                        }
                    }
                }
            };
            YJsonUtility.WriteToJson(datas,Msg.Paths.Config.Enemy);
        }
        
        [UnityEditor.MenuItem("Tools/重写写入PlayerDataJson")]
        private static void ReWriteData()
        {
            var playerData = new PlayerData()
            {
                property = new PlayerData.Property()
                {
                    Name = "小明",
                    Level  = 2,
                    Exp = 282,
                    Power = 100,
                    Hp = 200,
                    Attack = 10,
                    Defence = 8,
                    Speed = 10,
                    UpperPower = 100,
                    UpperHp = 200,
                    UpperAttack = 10,
                    UpperSpeed = 10
                },
                goodsDict = new Dictionary<string, int>()
                {
                    {"Coin",100},
                    {"馒头",5},
                }
            };
            YJsonUtility.WriteToJson<PlayerData>(playerData,Msg.Paths.Config.PlayerData);
        }

        [UnityEditor.MenuItem("Tools/打开EnemyEditorWindow %e")]
        private static void OpenEnemyEditorWindow()
        {
            EnemyEditor.Show();
        }
    }
#endif
}