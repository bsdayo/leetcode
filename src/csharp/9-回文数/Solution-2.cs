/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

namespace LeetCode.P9.S2;

// @lc code=start
public class Solution {
    public bool IsPalindrome(int x) {
        var str = x.ToString();
        return str == string.Concat(str.Reverse());
    }
}
// @lc code=end