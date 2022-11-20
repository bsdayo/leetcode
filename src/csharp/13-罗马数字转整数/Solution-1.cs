/*
 * @lc app=leetcode.cn id=13 lang=csharp
 *
 * [13] 罗马数字转整数
 */

namespace LeetCode.P13.S1;

// @lc code=start
public class Solution
{
    public int RomanToInt(string s)
    {
        var result = 0;
        var last = 0;

        foreach (var c in s)
        {
            var value = GetValue(c);
            // var value = RomanValues[c];
            result += value;
            if (value > last) result -= last * 2;
            last = value;
        }

        return result;
    }

    // public static Dictionary<char, int> RomanValues = new()
    // {
    //     { 'I', 1 },
    //     { 'V', 5 },
    //     { 'X', 10 },
    //     { 'L', 50 },
    //     { 'C', 100 },
    //     { 'D', 500 },
    //     { 'M', 1000 },
    // };

    public int GetValue(char c)
    {
        return c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
// @lc code=end