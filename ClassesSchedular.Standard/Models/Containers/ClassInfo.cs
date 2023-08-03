using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace ClassesSchedular.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<ClassInfo>),
        new Type[] {
            typeof(TalkInfoCase),
            typeof(SubjectInfoCase)
        },
        true
    )]
    public abstract class ClassInfo
    {
        /// <summary>
        /// Talks are mostly given to a versatile audience.
        /// </summary>
        /// <returns>
        /// The ClassInfo instance, wrapping the provided TalkInfo value.
        /// </returns>
        public static ClassInfo FromTalkInfo(TalkInfo talkInfo)
        {
            return new TalkInfoCase().Set(talkInfo);
        }

        /// <summary>
        /// Subjects are a deep study of a particular topic, given to an audience with limited set of skills.
        /// </summary>
        /// <returns>
        /// The ClassInfo instance, wrapping the provided SubjectInfo value.
        /// </returns>
        public static ClassInfo FromSubjectInfo(SubjectInfo subjectInfo)
        {
            return new SubjectInfoCase().Set(subjectInfo);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<TalkInfo, T> talkInfo, Func<SubjectInfo, T> subjectInfo);

        [JsonConverter(typeof(UnionTypeCaseConverter<TalkInfoCase, TalkInfo>))]
        private sealed class TalkInfoCase : ClassInfo, ICaseValue<TalkInfoCase, TalkInfo>
        {
            public TalkInfo _value;

            public override T Match<T>(Func<TalkInfo, T> talkInfo, Func<SubjectInfo, T> subjectInfo)
            {
                return talkInfo(_value);
            }

            public TalkInfoCase Set(TalkInfo value)
            {
                _value = value;
                return this;
            }

            public TalkInfo Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<SubjectInfoCase, SubjectInfo>))]
        private sealed class SubjectInfoCase : ClassInfo, ICaseValue<SubjectInfoCase, SubjectInfo>
        {
            public SubjectInfo _value;

            public override T Match<T>(Func<TalkInfo, T> talkInfo, Func<SubjectInfo, T> subjectInfo)
            {
                return subjectInfo(_value);
            }

            public SubjectInfoCase Set(SubjectInfo value)
            {
                _value = value;
                return this;
            }

            public SubjectInfo Get()
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