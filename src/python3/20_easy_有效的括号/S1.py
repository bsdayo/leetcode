#
# @lc app=leetcode.cn id=20 lang=python3
#
# [20] 有效的括号
#


# @lc code=start
class Solution:
    def isValid(self, s: str) -> bool:
        counts = [0, 0, 0]
        left = ["(", "[", "{"]
        right = [")", "]", "}"]
        pairs = {"(": ")", "[": "]", "{": "}"}
        stack = []

        for ch in s:
            if ch in left:
                counts[left.index(ch)] += 1
                stack.append(ch)
            else:  # right
                counts[right.index(ch)] -= 1
                if len(stack) == 0:
                    return False
                if pairs[stack[-1]] != ch:
                    return False
                stack.pop()

        return counts == [0, 0, 0]


# @lc code=end
