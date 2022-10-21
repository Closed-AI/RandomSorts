namespace RandomSorts.Sorts
{
    internal class SelectionSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                int min = i;

                for (int j = i; j < nums.Count; j++)
                {
                    if (nums[j] < nums[min])
                        min = j;
                }

                (nums[i], nums[min]) = (nums[min], nums[i]);
            }
        }
    }
}
