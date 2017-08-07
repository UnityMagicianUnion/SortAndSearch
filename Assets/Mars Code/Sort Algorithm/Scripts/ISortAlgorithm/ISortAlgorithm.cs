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
