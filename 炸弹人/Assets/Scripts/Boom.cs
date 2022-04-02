/****************************************************
    文件：Boom.cs
    作者：Y
    邮箱: 916111418@qq.com
    日期：#CreateTime#
    功能：Nothing
*****************************************************/

using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animation anim;
    private Animator effectAnim;
    private void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play();
    }

    private void Update()
    {
        if (anim.isPlaying ==false)
        {
            Destroy(this);
            //todo 后续操作
            CreateBoomEffect();
        }

        if (effectAnim !=null)
        {
            
        }
    }

    private void CreateBoomEffect()
    {
        var effectPreb = Resources.Load<GameObject>("Prefabs/BoomEffect");
        var effect =Instantiate(effectPreb, transform);
        effectAnim = effect.GetComponent<Animator>();
    }
}