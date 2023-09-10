using System.Diagnostics.CodeAnalysis;

namespace Mystat.Models
{
    public class StudentEquilityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Id == y.Id && x.FullName == y.FullName;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.Id;
        }
    }
}
