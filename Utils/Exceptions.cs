namespace Utils {
    /// <summary>
    /// Only Public Exceptions should be displayed to the user.
    /// </summary>
    public class PublicException : Exception {
        public PublicException(string message) : base(message) { }
    }

    public class AuthorizationException : PublicException {
        public static string DEFAULT_MESSAGE = "You are not authorized to view this content.";

        public AuthorizationException() : base(DEFAULT_MESSAGE) { }
        public AuthorizationException(string message) : base(message) { }
    }

    public class  NotFoundException : PublicException {
        public static string DEFAULT_MESSAGE = "Resourse not found.";

        public NotFoundException() : base(DEFAULT_MESSAGE) { }
        public NotFoundException(string message) : base(message) { }
    }

    public class AuthenticationException : PublicException {
        public static string DEFAULT_MESSAGE = "You must be authenticated to view this content.";

        public AuthenticationException() : base(DEFAULT_MESSAGE) { }
        public AuthenticationException(string message) : base(message) { }
    }
}