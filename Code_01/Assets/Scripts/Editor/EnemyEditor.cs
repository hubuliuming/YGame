/****************************************************
    文件：EnemyEditor.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using Code_01.Enemy;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Code_01.Editor
{
    public class EnemyEditor : EditorWindow
    {
        private static EnemyEditor win;
        private static readonly Rect _centerRectPos = new Rect(Screen.height / 2f, Screen.width / 2f, Screen.height / 2f, Screen.width / 2f);
        private static string _enemyName;
        private static string _tempEnemyName;
        private static int _Hp;
        private static int _tempHp;

        public static EnemyBase.EnemyData enemyData;
        
        internal new static void Show()
        {
            win= CreateWindow<EnemyEditor>();
            win.position = _centerRectPos;
            ClearCache();
        }
        
        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("请输入Enemy名字:",new GUILayoutOption[]{GUILayout.ExpandWidth(false)});
            _tempEnemyName = EditorGUILayout.TextField(_tempEnemyName,GUILayout.Width(50));
            if (GUILayout.Button("确认",GUILayout.ExpandWidth(false)))
            {
                _enemyName = _tempEnemyName;
                _tempEnemyName = "";
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            
            
            EditorGUILayout.LabelField("请输入Enemy血量:",new GUILayoutOption[]{GUILayout.ExpandWidth(false)});
            _tempHp = EditorGUILayout.IntField(_tempHp, GUILayout.Width(50));
            if (GUILayout.Button("确认",GUILayout.ExpandWidth(false)))
            {
                _Hp = _tempHp;
                _tempHp = 0;
            }
            EditorGUILayout.EndHorizontal();
            
            Debug.Log(_Hp);
        }

        private static void ClearCache()
        {
            _enemyName = "";
            _Hp = 0;
        }
    }
}
#endif