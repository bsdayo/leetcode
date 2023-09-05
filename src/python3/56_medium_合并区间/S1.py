#
# @lc app=leetcode.cn id=56 lang=python3
#
# [56] 合并区间
#

from typing import List


# @lc code=start
class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        # 先排序，这样就不用重复遍历
        intervals.sort(key=lambda i: i[0])

        result = []

        for interval in intervals:
            if len(result) == 0 or result[-1][1] < interval[0]:
                result.append(interval)
            else:
                result[-1][1] = max(result[-1][1], interval[1])

        return result


# @lc code=end
