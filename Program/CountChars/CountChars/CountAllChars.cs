namespace CountChars
{
    public static class CountAllChars
    {
        public static void Main() 
        {
            string file = Console.ReadLine();
            try
            {
                using(StreamReader sr = new StreamReader(file))
                {
                    string chars = sr.ReadToEnd();
                    Console.WriteLine(chars.Length);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}