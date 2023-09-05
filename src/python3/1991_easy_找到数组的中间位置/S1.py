#
# @lc app=leetcode.cn id=1991 lang=python3
#
# [1991] 找到数组的中间位置
#
from typing import List


# @lc code=start
class Solution:
    def findMiddleIndex(self, nums: List[int]) -> int:
        left = 0
        right = sum(nums)

        for index, num in enumerate(nums):
            if left == right - num:
                return index
            left += num
            right -= num

        return -1


# @lc code=end
