#
# @lc app=leetcode.cn id=28 lang=python3
#
# [28] 找出字符串中第一个匹配项的下标
#


# @lc code=start
class Solution:
    def strStr(self, haystack: str, needle: str) -> int:
        len_haystack = len(haystack)
        len_needle = len(needle)

        for i in range(len_haystack):
            if haystack[i] == needle[0] and len_haystack - i >= len_needle:
                if haystack[i : i + len_needle] == needle:
                    return i
        return -1


# @lc code=end
