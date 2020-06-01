using System;

namespace NumbersCodingTask.Utilities
{
    public static class Maybe
    {
        public static IMaybe<T> Just<T>(T value)
        {
            return new JustOf<T>(value);
        }

        public static IMaybe<T> None<T>()
        {
            return new NoneOf<T>();
        }

        private class JustOf<T1> : IMaybe<T1>
        {
            private readonly T1 _value;

            public JustOf(T1 value)
            {
                _value = value;
            }

            public bool HasValue()
            {
                return true;
            }

            public T1 Value()
            {
                return _value;
            }
        }

        private class NoneOf<T1> : IMaybe<T1>
        {
            public bool HasValue()
            {
                return false;
            }

            public T1 Value()
            {
                throw new InvalidOperationException("An optional value is not available.");
            }
        }
    }
}
