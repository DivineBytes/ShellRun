using System;
using System.ComponentModel;
using System.Reflection;

namespace ShellRun.Extensions
{
    /// <summary>
    /// The <see cref="EnumExtensions"/> class.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets the enum description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string GetEnumDescription(Enum value)
        {
            if (value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

                if (fieldInfo != null)
                {
                    if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes)
                    {
                        if (attributes.Length > 0)
                        {
                            return attributes[0].Description;
                        }
                    }

                    return value.ToString();
                }

            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the enum display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string GetEnumDisplayName(Enum value)
        {
            if (value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

                if (fieldInfo != null)
                {
                    if (fieldInfo.GetCustomAttributes(typeof(Attributes.DisplayNameAttribute), false) is Attributes.DisplayNameAttribute[] attributes)
                    {
                        if (attributes.Length > 0)
                        {
                            return attributes[0].DisplayName;
                        }
                    }

                    return value.ToString();
                }

            }

            return string.Empty;
        }
    }
}
