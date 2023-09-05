/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

namespace LeetCode.P14.S1;

// @lc code=start
using System.Text;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var resultSb = new StringBuilder();
        char now = ' ';
        for (var i = 0; i < strs.Min(s => s.Length); i++)
        {
            foreach (var str in strs)
            {
                if (str.Length < 0) goto end;
                if (now == ' ') now = str[i];
                else if (str[i] != now) goto end;
            }
            resultSb.Append(now);
            now = ' ';
        }

        end: return resultSb.ToString();
    }
}
// @lc code=end