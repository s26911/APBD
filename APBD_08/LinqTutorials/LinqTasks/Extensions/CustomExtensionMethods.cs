using System.Collections;
using LinqTasks.Models;

namespace LinqTasks.Extensions;

public static class CustomExtensionMethods
{
    //Put your extension methods here
    public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
    {
        return emps.Where(x=> emps.Any(y =>
        {
            if (y.Mgr != null)
                return y.Mgr.Empno == x.Empno;
            return false;
        })).OrderBy(x => new Tuple<string, int>(x.Ename, x.Salary), new comp());
    }

    private class comp : IComparer<Tuple<string, int>>
         {
             public int Compare(Tuple<string, int> x, Tuple<string, int> y)
             {
                 if (ReferenceEquals(x, y)) return 0;
                 if (ReferenceEquals(null, y)) return 1;
                 if (ReferenceEquals(null, x)) return -1;
                 var item1Comparison = string.Compare(x.Item1, y.Item1, StringComparison.Ordinal);
                 if (item1Comparison != 0) return item1Comparison;
                 return Comparer<int>.Default.Compare(x.Item2, y.Item2);
             }
         }
}