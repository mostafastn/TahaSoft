namespace Taha.Framework.Repository
{
    public class RepositoryResult<T>
    {
        public bool succeed { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
