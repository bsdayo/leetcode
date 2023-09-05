/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

namespace LeetCode.P14.S3;

// @lc code=start
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        // 找出最短字符串长度
        // var minLength = strs.Min(s => s.Length)
        var minLength = strs[0].Length;
        for (var i = 1; i < strs.Length; i++)
            if (strs[i].Length < minLength)
                minLength = strs[i].Length;

        byte end = 0;
        for (; end < minLength; end++)
            for (var i = 1; i < strs.Length; i++)
                if (strs[i][end] != strs[0][end])
                    return strs[0][..end];

        return strs[0][..end];
    }
}
// @lc code=end