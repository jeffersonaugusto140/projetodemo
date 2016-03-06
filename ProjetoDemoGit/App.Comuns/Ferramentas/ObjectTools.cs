namespace App.Comuns.Ferramentas
{
    public static class ObjectTools
    {
        public static T Cast<T>(this object o)
        {
            return (T) o;
        }
    }
}