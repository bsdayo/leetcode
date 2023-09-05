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
        for (var i = 0; ; i++)
            if (strs.Any(s => s.Length <= i || s[i] != strs[0][i]))
                return strs[0][..i];
    }
}
// @lc code=end