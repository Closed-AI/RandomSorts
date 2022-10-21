namespace RandomSorts.Sorts
{
    internal class MergeSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            if (nums.Count!=0)
            {
                List<int> buff = new List<int>(nums);
                MergeSortImpl(nums, buff, 0, nums.Count - 1);
            }
        }

        void MergeSortImpl(List<int> values, List<int> buff, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSortImpl(values, buff, l, m);
                MergeSortImpl(values, buff, m + 1, r);

                int k = l;
                for (int i = l, j = m + 1; i <= m || j <= r;)
                {
                    if (j > r || (i <= m && values[i] < values[j]))
                    {
                        buff[k] = values[i];
                        i++;
                    }
                    else
                    {
                        buff[k] = values[j];
                        j++;
                    }
                    k++;
                }
                for (int i = l; i <= r; i++)
                {
                    values[i] = buff[i];
                }
            }
        }
    }
}
