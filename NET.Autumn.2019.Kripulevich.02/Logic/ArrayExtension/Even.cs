namespace Logic
{
    class Even : IPredicate
    {
        public bool IsMatch(int number)
        {
            return number % 2 == 0;
        }
    }
}
