/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

namespace LeetCode.P14.S2;

// @lc code=start
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var first = strs[0];
        for (var i = 0; ; i++)
            if (strs.Any(s => s.Length <= i || s[i] != first[i]))
                return first[..i];
    }
}
// @lc code=end