using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSorts.Sorts
{
    internal class HeapSorter : ISorter
    {
        public void Sort(List<int> nums)
        {
            int n = nums.Count;

            for (int i = n / 2 - 1; i >= 0; --i)
                heapify(nums, n, i);

            for (int i = n - 1; i >= 0; --i)
            {
                (nums[0], nums[i]) = (nums[i], nums[0]);
                heapify(nums, i, 0);
            }
        }

        void heapify(List<int> nums, int n, int i)
        {
            int largest = i;
        
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && nums[l] > nums[largest])
                largest = l;

            if (r < n && nums[r] > nums[largest])
                largest = r;

            if (largest != i)
            {
                (nums[i], nums[largest]) = (nums[largest], nums[i]);

                heapify(nums, n, largest);
            }
        }
    }
}
