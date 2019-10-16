using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
        anim.SetBool("isMid", true);
    }

    // Update is called once per frame
    void Update()
    {
        //移动相关
        float movement = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        if (movement != 0&& anim.GetCurrentAnimatorStateInfo(0).IsName("isAttack") == false)
        {
            if (movement > 0.05f || movement < -0.05f)
            {
                anim.SetBool("isRun", true);//速度大于0.5才能开始跑步
                if(Input.GetKeyDown(KeyCode.S))
                {
                    anim.SetBool("isRun", false);
                    anim.SetTrigger("isRoll");//在跑步过程中才能够进行Roll动作，且跑步状态解除
                }
                else
                {
                    anim.SetBool("isRun", true);//恢复跑步
                }
            }
            else
            {
                anim.SetBool("isRun", false);//小于0.5边踱步
            }//需要更改增加踱步的状态！！！！！！！！！！！！！！！
            anim.SetBool("isIdle", false);
            // 如果movement值大于0，这表示玩家对象向右移动，所以将玩家对象向右转并进行移动
            if (movement > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(transform.right * movement);
            }
            else if (movement < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(transform.right * movement);
            }
        }
        else if (movement == 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("isAttack") == false)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", true);
        }
        //剑位置
        if(Input.GetKeyDown(KeyCode.S))//向下调剑的位置
        {
            if(anim.GetBool("isUp"))//如果在上剑位
            {
                anim.SetBool("isMid", true);
                anim.SetBool("isUp", false);
            }
            else if(anim.GetBool("isMid"))//在中剑位
            {
                anim.SetBool("isLow", true);
                anim.SetBool("isMid", false);
            }//本来在低剑位不作调整
        }
        else if(Input.GetKeyDown(KeyCode.W))//向上调剑的位置
        {
            if(anim.GetBool("isLow"))//在低剑位
            {
                anim.SetBool("isMid", true);
                anim.SetBool("isLow", false);
            }
            else if(anim.GetBool("isMid"))//中剑位
            {
                anim.SetBool("isUp", true);
                anim.SetBool("isMid", false);
            }
        }
        //攻击相关
        if (Input.GetKey(KeyCode.J))//J键攻击
        {
            anim.SetBool("isAttack", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }
}
