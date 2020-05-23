namespace AcademiaDemo.Domain.Comum
{
    public class ClientRest<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T ReadToObject { get; set; }
    }
}
