using System;

namespace ShellRun.Attributes
{
    /// <summary>
    /// The <see cref="DisplayNameAttribute"/> attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DisplayNameAttribute : Attribute
    {
        /// <summary>
        /// The default property.
        /// </summary>
        public static readonly DisplayNameAttribute Default = new DisplayNameAttribute();

        private string _displayName;

        /// <summary>
        /// The display name.
        /// </summary>
        public virtual string DisplayName => DisplayNameValue;

        /// <summary>
        /// The display name value.
        /// </summary>
        protected string DisplayNameValue
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        /// <summary>
        /// The <see cref="DisplayNameAttribute"/>.
        /// </summary>
        public DisplayNameAttribute() : this(string.Empty)
        {
        }

        /// <summary>
        /// The <see cref="DisplayNameAttribute"/>.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public DisplayNameAttribute(string displayName)
        {
            _displayName = displayName;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj is DisplayNameAttribute displayNameAttribute)
            {
                return displayNameAttribute.DisplayName == DisplayName;
            }

            return false;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        public override int GetHashCode()
        {
            return DisplayName.GetHashCode();
        }

        /// <summary>
        /// The is default attribute.
        /// </summary>
        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
}