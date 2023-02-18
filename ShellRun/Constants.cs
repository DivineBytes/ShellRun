namespace ShellRun
{
    /// <summary>
    /// The <see cref="Constants"/> class.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The separator.
        /// </summary>
        public const char Separator = ';';

        /// <summary>
        /// The <see cref="ExceptionMessages"/> class.
        /// </summary>
#pragma warning disable 1591

        public class ExceptionMessages
        {
            public const string CannotBeNull = "Cannot be null.";
            public const string CannotBeNullOrEmpty = "Cannot be null or empty.";
            public const string FileNotFound = "The file cannot be found.";
        }
    }
}