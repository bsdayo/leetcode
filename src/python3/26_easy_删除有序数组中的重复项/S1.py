#
# @lc app=leetcode.cn id=26 lang=python3
#
# [26] 删除有序数组中的重复项
#

from typing import List


# @lc code=start
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        last = None
        count = 0
        for n in nums[:]:
            if last != n:
                count += 1
                last = n
            else:
                nums.remove(n)

        return count


# @lc code=end
