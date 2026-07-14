using IMS.Core.Common;

namespace IMS.Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }


        private Role()
        {
        }

        public Role(string name, string? description)
        {
            Name = name;
            Description = description;
            IsActive = true;
        }

    }
}
