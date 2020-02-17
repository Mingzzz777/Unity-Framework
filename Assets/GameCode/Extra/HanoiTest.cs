using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//此脚本与游戏框架无关，只是学习汉诺塔时使用的脚本
public class HanoiTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hanoi(3, 'A','B','C');
    }

    //表示把多少个圆盘从起始杆移动到目标杆，此处的ABC代表着杆的意义，如A为起始，B为辅助杆，C为目标杆。
    void Hanoi(int n,char A,char B,char C)
    {
        print("Hanio(" + A + "," + B + "," + C + ")");
        //当只有一个圆盘时，直接从A移动到C
        if (n == 1)
            Move(n, A, C);
        else
        {
            //否则,n-1个圆盘移到B杆，C杆作为辅助杆,每次转移n个圆盘时，现将n-1个圆盘放到辅助杆，再把A移到目标杆，再把辅助杆上的n-1个圆盘移动到目标杆。
            Hanoi(n - 1, A, C, B); // 此处的A,C,B在每次递归时相当于交换辅助杆和目标杆。
            //然后将第n个杆移动到C杆
            Move(n, A, C);
            //然后将n-1个圆盘移回C杆
            Hanoi(n - 1, B, A, C);
            
        }

    }

    /// <summary>
    /// 把第几个圆盘进行移动
    /// </summary>
    /// <param name="n">移动第几个圆盘</param>
    /// <param name="from">从哪根杆上移动</param>
    /// <param name="to">移动到哪根杆上去</param>
    void Move(int n,char from,char to)
    {
        print("第" + n + "个圆盘从杆" + from + "移动到杆" + to);
    }
}
