/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

namespace LeetCode.P1.S1;

// @lc code=start
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        // no solution
        return new[] { -1, -1 };
    }
}
// @lc code=end