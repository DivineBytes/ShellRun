using System;

namespace ShellRun.Test.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class NotTestedAttribute : Attribute
    {
        public static readonly NotTestedAttribute Default = new NotTestedAttribute();

        private string _description;

        public virtual string Description => DescriptionValue;

        protected string DescriptionValue
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public NotTestedAttribute() : this(string.Empty)
        {
        }

        public NotTestedAttribute(string displayName)
        {
            _description = displayName;
        }

#pragma warning disable 8765

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj is NotTestedAttribute displayNameAttribute)
            {
                return displayNameAttribute.Description == Description;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
}