namespace NumbersCodingTask.Utilities
{
    // Container type for a value that might not exist. Used instead of "null" values to make
    // the optionality of wrapped type more explicit and to avoid using "null" in general.
    // Equivalent container types exists in various other programming languages and usually go
    // by the names like "Optional", "Option", "Opt", etc.
    public interface IMaybe<out T>
    {
        bool HasValue();
        T Value();
    }
}
