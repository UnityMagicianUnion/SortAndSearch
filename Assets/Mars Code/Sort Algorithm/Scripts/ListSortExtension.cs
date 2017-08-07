/**************************************************
* 描述
*   整合了常用的排序法，資料型態為 IComparable 泛型
* 
* 說明
*   快速排序法(不穩定排序)
*   - 絕大部分使用都會得到很好的效率
*   - 不適合用在已經大致排序過的資料對象
*   - 不適合用於反轉排序
*   
*   插入排序法(穩定排序)
*   - 針對已經大致排序過的資料會有非常優秀的效率
*   - 需要穩定排序的時候
*   
*   希爾排序法(不穩定排序)
*   - 資料長度較小
*   - 適合用於反轉排序
*   
*   堆積排序法(不穩定排序)
*   - 資料長度很大的時候
*   
* 用法
*   引用 ListSortExtension
*   泛型 T 必須實作 IComparable 介面
*   ex-> list.HeapSort() 即可使用堆積排序法進行排序
**************************************************/

namespace ListSortAlgorithm
{
    using System;
    using System.Collections.Generic;

    public static class ListSortExtension
    {

        // 資料內容的元素交換
        public static void Swap<T>(this List<T> data, int index1, int index2)
        {
            if(index1 == index2)
                return;

            T temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }


        // 快速排序法
        public static void QuickSort<T>(this List<T> data) where T : IComparable<T>
        {
            QuickSort(data, 0, data.Count - 1);
        }


        // 快速排序法子功能
        static void QuickSort<T>(List<T> data, int left, int right) where T : IComparable<T>
        {
            if(left >= right)
                return;

            var i = left - 1;   // 指派左側索引
            var j = right;      // 指派右側索引

            while(i < j)
            {
                // i 遞增並且往右尋找大於或等於基準的對象，i 必須小於 j
                while(++i < j && data[i].CompareTo(data[right]) < 0)
                    ;

                // j 遞減並且往左尋找小於或等於基準的對象，j 必須大於 i
                while(--j > i && data[j].CompareTo(data[right]) > 0)
                    ;

                // 交換元素並且繼續迴圈
                if(i < j)
                    Swap(data, i, j);
            }

            // 將基準物件與 i 物件交換
            Swap(data, i, right);
            QuickSort(data, left, i - 1);   // 切割指標 i 左側物件的遞迴排序
            QuickSort(data, i + 1, right);  // 切割指標 i 右側物件的遞迴排序
        }


        // 插入排序法
        public static void InsertionSort<T>(this List<T> data) where T : IComparable<T>
        {
            var n = data.Count;
            int i, j;
            T temp;

            for(i = 1; i < n; i++)
            {
                // 設定該次迴圈的插入元素 temp
                temp = data[i];

                // 設定指標 j 的起始位置
                j = i - 1;

                // 將插入元素與逐左的指標元素比對，若指標元素較大則指標元素往右移動
                while(j > -1 && data[j].CompareTo(temp) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                // 將插入元素放到指標的位置
                data[j + 1] = temp;
            }
        }


        // 希爾排序法
        public static void ShellSort<T>(this List<T> data) where T : IComparable<T>
        {
            var n = data.Count;
            var gap = n / 2;
            int i, j;
            T temp;

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
                    while(j > -1 && data[j].CompareTo(temp) > 0)
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


        // 堆積排序法
        public static void HeapSort<T>(this List<T> data) where T : IComparable<T>
        {
            int n = data.Count;

            // 取得最後一個父節點 p，並且逐左將資料轉化為最大堆積樹
            for(var p = (n / 2) - 1; p >= 0; p--)
                MaxHeapify(data, p, n);

            // 指標 n 每經過一次迴圈會往左移動。
            for(n = n - 1; n > 0; n--)
            {
                // 將首位元素與指標元素 n 置換。
                Swap(data, 0, n);

                // 首位元素產生了變化
                // 在不包含指標 n 的範圍內將資料執行最大堆積化
                MaxHeapify(data, 0, n);
            }
        }


        // 堆積排序法子功能
        static void MaxHeapify<T>(List<T> data, int parent, int range) where T : IComparable<T>
        {
            // 預設最大值位於父結點
            int max = parent;

            // 取得左右子樹的索引
            int leafL = parent * 2 + 1;
            int leafR = parent * 2 + 2;

            // 與左子樹比較取得最大值
            if(leafL < range && data[leafL].CompareTo(data[max]) > 0)
                max = leafL;

            // 與右子樹比較取得最大值
            if(leafR < range && data[leafR].CompareTo(data[max]) > 0)
                max = leafR;

            // 若子樹的值較大則與父節點置換，該子樹往下遞迴檢測
            // 所有遞迴完成之後資料將規範化為最大堆積樹
            if(max != parent)
            {
                Swap(data, parent, max);
                MaxHeapify(data, max, range);
            }
        }

    }

}




