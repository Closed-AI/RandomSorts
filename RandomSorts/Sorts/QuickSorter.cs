using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RandomSorts.Sorts
{
    internal class QuickSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            if (nums.Count!=0)
            {
                QuickSortImpl(nums, 0, nums.Count - 1);
            }
        }
        
        void QuickSortImpl(List<int> nums, int l, int r)
        {
            if (l < r)
            {
                int q = Partition(nums, l, r);
                QuickSortImpl(nums, l, q - 1);
                QuickSortImpl(nums, q + 1, r);
            }
        }

        int Partition(List<int> nums, int l, int r)
        {
            int x = nums[r];
            int less = l;

            for (int i = l; i < r; ++i)
            {
                if (nums[i] <= x)
                {
                    (nums[i], nums[less]) = (nums[less], nums[i]);
                    ++less;
                }
            }
            (nums[less], nums[r]) = (nums[r], nums[less]);
            return less;
        }
    }
}
