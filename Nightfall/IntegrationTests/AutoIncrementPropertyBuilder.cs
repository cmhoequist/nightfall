using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class AutoIncrementPropertyBuilder<TEntity> : ISpecimenBuilder
    {
        private int _currentId;
        private PropertyInfo _property;

        public AutoIncrementPropertyBuilder(Expression<Func<TEntity, int>> getter, int initialValue)
        {
            _currentId = initialValue;
            _property = (PropertyInfo)((MemberExpression)getter.Body).Member;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var property = request as PropertyInfo;
            if (property != null && AreEquivalent(property, _property))
            {
                _currentId += 1;
                return _currentId;
            }
            return new NoSpecimen();
        }

        private bool AreEquivalent(PropertyInfo first, PropertyInfo second)
        {
            return first.DeclaringType == second.DeclaringType && first.Name == second.Name;
        }

    }
}
