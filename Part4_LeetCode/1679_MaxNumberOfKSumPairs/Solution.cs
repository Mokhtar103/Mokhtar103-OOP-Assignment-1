using System;

public class Solution
{
    public static int MaxOperations(int[] nums, int k)
    {
        int left = 0;
        int right = nums.Length - 1;
        int count = 0;

        Array.Sort(nums);

        while (left < right)
        {
            var currentSum = nums[left] + nums[right];
            if (currentSum == k)
            {
                left++;
                right--;
                count++;
            }
            else if (currentSum < k)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return count;
    }
}