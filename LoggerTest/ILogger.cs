namespace LoggerTest
{
    public interface ILogger
    {
        // -----------------------------------------------------
        // ILogger defines the elements of a basic log class.
        // Classes that implement the ILogger interface must
        // match this signature at a minimum.
        // -----------------------------------------------------
        string Logged { get; set; }
        string Message { get; set; }
        string Path { get; set; }

        void AppendLog();
    }
}