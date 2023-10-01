namespace recipes.Helpers
{
    public class Operation<T>
    {
        public bool Completed { get; set; } = false;

        public List<T>? Payload { get; set; } = null;

        public string? ErrorMessage { get; set; } = string.Empty;
    }
}