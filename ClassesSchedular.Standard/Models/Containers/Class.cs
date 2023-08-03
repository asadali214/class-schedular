using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace ClassesSchedular.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<Class>),
        new Type[] {
            typeof(SeminarCase),
            typeof(LectureCase)
        },
        true
    )]
    public abstract class Class
    {
        /// <summary>
        /// Seminars are held in front of larger audience.
        /// </summary>
        /// <returns>
        /// The Class instance, wrapping the provided Seminar value.
        /// </returns>
        public static Class FromSeminar(Seminar seminar)
        {
            return new SeminarCase().Set(seminar);
        }

        /// <summary>
        /// Lectures are held for smaller audience.
        /// </summary>
        /// <returns>
        /// The Class instance, wrapping the provided Lecture value.
        /// </returns>
        public static Class FromLecture(Lecture lecture)
        {
            return new LectureCase().Set(lecture);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<Seminar, T> seminar, Func<Lecture, T> lecture);

        [JsonConverter(typeof(UnionTypeCaseConverter<SeminarCase, Seminar>))]
        private sealed class SeminarCase : Class, ICaseValue<SeminarCase, Seminar>
        {
            public Seminar _value;

            public override T Match<T>(Func<Seminar, T> seminar, Func<Lecture, T> lecture)
            {
                return seminar(_value);
            }

            public SeminarCase Set(Seminar value)
            {
                _value = value;
                return this;
            }

            public Seminar Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<LectureCase, Lecture>))]
        private sealed class LectureCase : Class, ICaseValue<LectureCase, Lecture>
        {
            public Lecture _value;

            public override T Match<T>(Func<Seminar, T> seminar, Func<Lecture, T> lecture)
            {
                return lecture(_value);
            }

            public LectureCase Set(Lecture value)
            {
                _value = value;
                return this;
            }

            public Lecture Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }
    }
}