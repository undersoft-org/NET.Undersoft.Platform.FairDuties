namespace System.Extract
{
    using System.Instant;
    using System.Linq;
    using System.Reflection;

    public static class FigureMocks
    {
        public static MemberInfo[] Figure_MemberRubric_FieldsAndPropertiesModel()
        {
            return typeof(FieldsAndPropertiesModel)
                .GetMembers()
                .Select(
                    m =>
                        m.MemberType == MemberTypes.Field
                            ? new MemberRubric((FieldInfo)m)
                            : m.MemberType == MemberTypes.Property
                                ? new MemberRubric((PropertyInfo)m)
                                : null
                )
                .Where(p => p != null)
                .ToArray();
        }
    }
}
