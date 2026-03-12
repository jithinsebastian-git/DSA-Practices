public class Solution
{
    public static int LengthOfLongestSubstring(string s)
    {
        int maxLength = 0;
        int left = 0;
        HashSet<char> charSet = new HashSet<char>();
        for (int right = 0; right < s.Length; right++)
        {
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left]);
                left++;
            }
            charSet.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
    public static void Main()
    {
        string input = "abcabcbb";
        int result = LengthOfLongestSubstring(input);
        Console.WriteLine($"The length of the longest substring without repeating characters in \"{input}\" is: {result}");
    }
}