/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

namespace LeetCode.P9.S1;

// @lc code=start
public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        if (x < 10) return true;

        // 得到数字位数
        var digit = 0;
        var temp = x;
        while (temp > 0)
        {
            temp = temp / 10;
            digit++;
        }

        for (var i = 1; i <= digit / 2; i++)
        {
            var left = (byte)(x / Math.Pow(10, digit - i) % 10);
            var right = (byte)(x / Math.Pow(10, i - 1) % 10);
            if (left != right) return false;
        }

        return true;
    }
}
// @lc code=end

public static class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.IsPalindrome(1000021));
    }
}