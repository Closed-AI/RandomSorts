namespace RandomSorts.Sorts
{
    internal class InsertionSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            for (int i = 1; i < nums.Count; i++)
            {
                int x = nums[i];
                int j = i;
                while (j > 0 && nums[j - 1] > x)
                {
                    nums[j] = nums[j - 1];
                    j--;
                }
                nums[j] = x;
            }
        }
    }
}
