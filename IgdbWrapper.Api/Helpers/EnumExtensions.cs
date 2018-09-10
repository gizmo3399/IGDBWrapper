using System;
using System.ComponentModel;

namespace IgdbWrapper.Api.Helpers
{
    /// <summary>
    /// Extensions for Enum classes.
    /// Credit to: Nitin Chaudhari
    /// <remarks>Copied from: http://www.extensionmethod.net/5403/csharp/enum/enum-hasdescription </remarks>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the value of a <see cref="DescriptionAttribute"/> of the specified Enum type if present.
        /// </summary>
        /// <param name="someEnum">The enum type to get the description of.</param>
        /// <returns>The value of the <see cref="DescriptionAttribute"/> of the selected enum type. or the <c>ToString()</c> of the selected enum type if no description was provided.</returns>
        public static string Description(this Enum someEnum)
        {
            var memInfo = someEnum.GetType().GetMember(someEnum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return someEnum.ToString();
        }

        /// <summary>
        /// Checks to see if the specified enum type has a <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="someEnum">The enum type to check for the <see cref="DescriptionAttribute"/>.</param>
        /// <returns><c>true</c> if the specified enum type has a <see cref="DescriptionAttribute"/>, <c>false</c> otherwise.</returns>
        public static bool HasDescription(this Enum someEnum)
        {
            return !string.IsNullOrWhiteSpace(someEnum.Description());
        }

        /// <summary>
        /// Checks to see if the specified enum type has a <see cref="DescriptionAttribute"/> and if so if it has a specific description.
        /// </summary>
        /// <param name="someEnum">The enum type to check for the <see cref="DescriptionAttribute"/>.</param>
        /// <param name="expectedDescription">The expected value of the <see cref="DescriptionAttribute"/>.</param>
        /// <returns><c>true</c> if the specified enum type has a <see cref="DescriptionAttribute"/> with the <see cref="expectedDescription"/>, <c>false</c> otherwise.</returns>
        public static bool HasDescription(this Enum someEnum, string expectedDescription)
        {
            return someEnum.Description().Equals(expectedDescription);
        }

        /// <summary>
        /// Checks to see if the specified enum type has a <see cref="DescriptionAttribute"/> and if so if it has a specific description.
        /// </summary>
        /// <param name="someEnum">The enum type to check for the <see cref="DescriptionAttribute"/>.</param>
        /// <param name="expectedDescription">The expected value of the <see cref="DescriptionAttribute"/>.</param>
        /// <param name="comparisionType">The method of string comparison to check the <see cref="expectedDescription"/>.</param>
        /// <returns><c>true</c> if the specified enum type has a <see cref="DescriptionAttribute"/> with the <see cref="expectedDescription"/>, <c>false</c> otherwise.</returns>
        public static bool HasDescription(this Enum someEnum, string expectedDescription, StringComparison comparisionType)
        {
            return someEnum.Description().Equals(expectedDescription, comparisionType);
        }
    }
}