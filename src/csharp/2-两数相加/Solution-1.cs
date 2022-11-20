/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 */

namespace LeetCode.P2.S1;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

// @lc code=start
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        ListNode resultRef = result;
        ListNode? l1Ref = l1;
        ListNode? l2Ref = l2;
        var sum = 0;

        while (l1Ref is not null || l2Ref is not null)
        {
            sum += (l1Ref?.val ?? 0) + (l2Ref?.val ?? 0);
            resultRef.val = sum % 10;   // 取个位
            sum = sum / 10;   // 进位

            // l1 l2 中有一个以上有下一节点，或者都没节点了但要进位
            if (l1Ref?.next is not null || l2Ref?.next is not null || sum > 0)
                resultRef.next = new ListNode(sum);

            resultRef = resultRef.next!;
            l1Ref = l1Ref?.next;
            l2Ref = l2Ref?.next;
        }

        return result;
    }
}
// @lc code=end

public static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        solution.AddTwoNumbers(l1, l2);
    }
}