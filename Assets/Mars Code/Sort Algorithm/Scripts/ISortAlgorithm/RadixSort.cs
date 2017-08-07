/**************************************************
* 基數排序法
* 
* 介紹:
* 依據十進位的規則對資料做箱子的分割排序，最後合併即完成排序
* 
* 最壞時間: O(nlogb B)
* 平均時間: O(n)~O(nlogbk) k為箱子數，b為基數  
* 額外空間: O(nb)
* 
* 排序方式: 穩定排序
**************************************************/

using System;

public class RadixSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var temp = new int[data.Length];
        var n = data.Length;

        int i, j, shift;
        bool move;

        for(shift = 31; shift > -1; --shift)
        {
            j = 0;

            for(i = 0; i < n; ++i)
            {
                move = (data[i] << shift) >= 0;

                if(shift == 0 ? !move : move)
                    data[i - j] = data[i];
                else
                    temp[j++] = data[i];
            }

            Array.Copy(temp, 0, data, data.Length - j, j);
        }
    }

}