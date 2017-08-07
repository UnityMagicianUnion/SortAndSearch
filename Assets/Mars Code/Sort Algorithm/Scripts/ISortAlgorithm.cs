using System;

// 排序演算法的抽象父型別
public abstract class ISortAlgorithm
{

    public abstract void Sort(int[] data);


    protected void Swap(int[] data, int index1, int index2)
    {
        if(index1 == index2)
            return;

        data[index1] = data[index1] ^ data[index2];
        data[index2] = data[index1] ^ data[index2];
        data[index1] = data[index1] ^ data[index2];
    }

}


// 氣泡排序法 
public class BubbleSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        var flag = true;
        int i, j;

        // 第一層迴圈決定要比對的次數，而 i 也決定了第二層迴圈的終點
        for(i = 1; i < n && flag; i++)
        {
            // 判斷是否結束排序的 flag
            flag = false;

            // 第二層迴圈會從第一個元素比對右邊鄰近的元素
            // 之後再從第二個元素與其右邊元素進行比對，依此類推
            for(j = 0; j < n - i; j++)
            {
                // 當比對的元素大於右邊相鄰的元素，則進行置換
                if(data[j] > data[j + 1])
                {
                    Swap(data, j, j + 1);
                    flag = true;
                }
            }
        }
    }

    /**************************************************
    * 說明:
    * 最常使用的排序演算法
    * 將元素與右邊的元素逐一往右兩兩比對，若左邊元素較大則與右邊元素置換
    * 每一輪的比對範圍內的最大元素會置換到範圍內的末位
    * 
    * 最壞時間: O(n²)
    * 平均時間: O(n²)
    * 額外空間: O(1)
    * 
    * 排序方式: 穩定排序
    * 使用時機: n的數量小 
    **************************************************/

}


// 選擇排序法 
public class SelectionSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        int i, j, min;

        for(i = 0; i < n - 1; i++)
        {
            // 指標 min 每經過一次迴圈會往右移動
            min = i;

            // 從指標的右邊逐一尋找最小的元素
            for(j = i + 1; j < n; j++)
            {
                if(data[j] < data[min])
                {
                    min = j;
                }
            }

            // 將指標元素與最小元素進行置換
            Swap(data, i, min);
        }
    }

    /**************************************************
    * 說明:
    * 由氣泡排序法演化而來
    * 藉由只選擇最小元素來減少元素頻繁調換的次數
    * 在每一輪的比對尋找最小元素，並且將範圍內的首位元素與最小元素置換。
    * 每一輪比對只會置換一次，而範圍指標會隨著每一輪的結束往右移動。
    * 
    * 最壞時間: O(n²)
    * 平均時間: O(n²)
    * 額外空間: O(1)
    * 
    * 排序方式: 不穩定排序
    * 使用時機: n的數量小
    **************************************************/

}


// 堆積排序法
public class HeapSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;

        // 取得最後一個父節點 p，並且逐左將資料轉化為最大堆積樹
        for(var p = (n / 2) - 1; p >= 0; p--)
            MaxHeapify(data, p, n);

        // 指標 n 每經過一次迴圈會往左移動。
        for(n = data.Length - 1; n > 0; n--)
        {
            // 將首位元素與指標元素 n 置換。
            Swap(data, 0, n);

            // 首位元素產生了變化
            // 在不包含指標 n 的範圍內將資料執行最大堆積化
            MaxHeapify(data, 0, n);
        }
    }


    // 依據代入的索引取得左右子樹，並且進行資料的最大堆積化
    void MaxHeapify(int[] data, int node, int range)
    {
        // 預設最大值位於根結點
        int max = node;

        // 取得左右子樹的索引
        int leafL = node * 2 + 1;
        int leafR = node * 2 + 2;

        // 與左子樹比較取得最大值
        if(leafL < range && data[leafL] > data[max])
            max = leafL;

        // 與右子樹比較取得最大值
        if(leafR < range && data[leafR] > data[max])
            max = leafR;

        // 若子樹的值較大則與父節點置換，該子樹往下遞迴檢測
        // 所有遞迴完成之後資料將規範化為最大堆積樹
        if(max != node)
        {
            Swap(data, node, max);
            MaxHeapify(data, max, range);
        }
    }

    /**************************************************
    * 說明:
    * 選擇排序法的改良演算法
    * 將資料轉化為最大堆積樹，並且將首位元素與指標元素進行置換
    * 指標元素一開始等同於資料的末位元素，之後指標會持續往左邊移動。
    * 
    * 最壞時間: O(nlog n)
    * 平均時間: O(nlog n)
    * 額外空間: O(1)
    * 
    * 排序方式: 不穩定排序
    * 使用時機: n的數量大
    **************************************************/

}


// 快速排序法
public class QuickSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        Sort(data, 0, data.Length - 1);
    }


    void Sort(int[] data, int left, int right)
    {
        if(left >= right)
            return;

        var i = left - 1;   // 指派左側索引
        var j = right;      // 指派右側索引

        while(i < j)
        {
            // 往右尋找大於或等於基準的索引值
            while(++i < j && data[i] < data[right])
                ;

            // 往左尋找小於或等於基準的索引值
            while(--j > i && data[j] > data[right])
                ;

            // 交換元素並且繼續迴圈
            if(i < j)
                Swap(data, i, j);
        }

        Swap(data, i, right);       // 調換指標元素與 i 元素
        Sort(data, left, i - 1);    // 切割指標 i 左側物件的遞迴排序
        Sort(data, i + 1, right);   // 切割指標 i 右側物件的遞迴排序
    }

    /**************************************************
    * 說明:
    * 大部分情況下效率良好的排序法
    * 每一輪將
    * 
    * 最壞時間: O(n²)
    * 平均時間: O(nlog n)
    * 額外空間: O(log n)~O(n)
    * 
    * 排序方式: 不穩定排序
    * 使用時機: n的數量大
    **************************************************/

}


// 插入排序法
public class InsertionSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        int i, j, temp;

        for(i = 1; i < n; i++)
        {
            // 指派該次迴圈的插入元素 temp
            temp = data[i];

            // 設定指標 j 的起始位置
            j = i - 1;

            // 將插入元素與逐左的指標元素比對
            // 若指標元素較大則指標元素往右移動
            while(j > -1 && data[j] > temp)
            {
                data[j + 1] = data[j];
                j--;
            }

            // 將插入元素放到指標的位置
            data[j + 1] = temp;
        }
    }

    /**************************************************
    * 說明:
    * 將資料分成"已排序"與"未排序"兩個部分
    * 並且將未排序的元素逐一與已排序的元素比對並排序到適當的位置
    * 
    * 最壞時間: O(n²)
    * 平均時間: O(n²)
    * 額外空間: O(1)
    * 
    * 排序方式: 穩定排序
    * 使用時機: 已經大致排序過的對象
    **************************************************/

}


// 希爾排序法 
public class ShellSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        var gap = n / 2;
        int i, j, temp;

        while(gap > 0)
        {
            for(i = gap; i < n; i++)
            {
                // 指派該次迴圈的插入元素 temp
                temp = data[i];

                // 設定指標 j 的起始位置
                j = i - gap;

                // 將插入元素與依據間隔逐左的指標元素比對
                // 若指標元素較大則指標元素往右移動
                while(j > -1 && data[j] > temp)
                {
                    data[j + gap] = data[j];
                    j -= gap;
                }

                data[j + gap] = temp;
            }

            // 間隔的範圍除以2
            gap /= 2;
        }
    }

    /**************************************************
    * 介紹:
    * 插入排序法的改良版
    * 定義一個間隔，並且以間隔為依據進行插入排序
    * 每經過一次迴圈，間隔的值會除以2
    * 
    * 最壞時間: O(n^s)
    * 平均時間: O(nlog n)
    * 額外空間: O(1)
    * 
    * 排序方式: 不穩定排序
    * 使用時機: n的數量小，反轉排序
    **************************************************/

}


// 基數排序法
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

    /**************************************************
    * 介紹:
    * 依據十進位的規則對資料做箱子的分割排序，最後合併即完成排序
    * 
    * 最壞時間: O(nlogb B)
    * 平均時間: O(n)~O(nlogbk) k為箱子數，b為基數  
    * 額外空間: O(nb)
    * 
    * 排序方式: 穩定排序
    **************************************************/

}


// 雞尾酒排序法
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

    /**************************************************
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

}