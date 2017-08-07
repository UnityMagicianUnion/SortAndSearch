/**************************************************
* 雞尾酒排序法
* 
* 說明:
* 由氣泡排序法演化而來
* 雞尾酒排序法會對兩個方向進行比對排序，並且將比對範圍往中間收束
* 
* 最壞時間: O(n²)
* 平均時間: O(n²)
* 額外空間: O(1)
* 
* 排序方式: 穩定排序
* 使用時機: n的數量小
**************************************************/


public class CocktailSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var left = 0;
        var right = data.Length - 1;
        int i;
        bool flag = true;

        while(left < right && flag)
        {
            flag = false;

            for(i = left; i < right; i++)
            {
                if(data[i] > data[i + 1])
                {
                    Swap(data, i, i + 1);
                    flag = true;
                }
            }
            right--;

            for(i = right; i > left; i--)
            {
                if(data[i - 1] > data[i])
                {
                    Swap(data, i, i - 1);
                    flag = true;
                }
            }
            left++;
        }
    }

}