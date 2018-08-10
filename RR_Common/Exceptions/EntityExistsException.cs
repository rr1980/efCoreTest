using System;
using System.Linq.Expressions;

namespace RR_Common.Exceptions
{
    public class EntityExistsException<T> : Exception
    {
        public EntityExistsException(T entity, Expression<Func<T, object>> compareProperty)
            : base(ModifyMessage(entity, compareProperty))
        {
        }

        private static string ModifyMessage(T entity, Expression<Func<T, object>> compareProperty)
        {
            var prop = (compareProperty.Body as MemberExpression);
            var value = compareProperty.Compile()(entity);

            return $"Es existiert bereits eine Entity vom Type '{typeof(T).Name}' mit dem gleichen Property-Wert '{prop.Member.Name}: {value}'";
        }
    }
}
