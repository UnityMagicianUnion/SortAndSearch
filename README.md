# Sort And Search
排序與搜尋的演算法整理

<br/><br/>

Version 
---
>v1.0.0<br/>
>August 7, 2017 Released

<br/><br/>

Feature
---
>針對 int 陣列整理了比較常見的排序演算法<br/>
>針對 IComparable 泛型整理了比較實用的排序演算法

<br/><br/>

Usage
---

>**int 陣列 (ISortAlgorithm.cs)**
```
var max = 30;
var data = new int[max];

for(int i = 0; i < max; i++)
    data[i] = Random.Range(0, 100);
    
// 選擇並實例化需要的排序演算法 
ISortAlgorithm sort = new QuickSort();
sort.Sort(data);
```
<br/>

>**IComparable 泛型 (MyComparableClass.cs)**

```
int max = 30;
var data = new List<MyComparableClass>();

for(int i = 0; i < max; i++)
    data.Add(new MyComparableClass(i, Random.Range(0, 100)));

// 選擇排序演算法
data.ShellSort();
```