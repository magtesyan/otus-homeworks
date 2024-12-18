namespace Classes
{
    public static class StackExtensions
    {
        public static void Merge(this Stack s1, Stack s2)
        {
            while (s2.Size > 0)
            {
                string topElementFromS2 = s2.Pop() ?? "";
                if (!string.IsNullOrEmpty(topElementFromS2))
                {
                    s1.Add(topElementFromS2);
                }
            }
        }
    }
}
