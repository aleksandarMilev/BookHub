﻿namespace BookHub.Server.Common.Messages
{
    public static class Error
    {
        public static class Book
        {
            public const string BookNotFound = "The book was not found!";

            public const string UnauthorizedBookEdit = "Current user can not edit this book!";

            public const string UnauthorizedBookDelete = "Current user can not delete this book!";
        }

        public static class Identity
        {
            public const string InvalidLoginAttempt = "Invalid log in attempt!";
        }
    }
}
