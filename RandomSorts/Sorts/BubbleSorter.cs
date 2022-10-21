namespace RandomSorts.Sorts
{
    internal class BubbleSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            for (int i = 0; i + 1 < nums.Count; i++)
            {
                for (int j = 0; j + 1 < nums.Count - i; j++)
                {
                    if (nums[j + 1] < nums[j])
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                    }
                }
            }
        }
    }
}
