#
# @lc app=leetcode.cn id=724 lang=python3
#
# [724] 寻找数组的中心下标
#

from typing import List


# @lc code=start
class Solution:
    def pivotIndex(self, nums: List[int]) -> int:
        total = sum(nums)
        left = 0
        for index, num in enumerate(nums):
            if total - left - num == left:
                return index
            left += num
        return -1


# @lc code=end
