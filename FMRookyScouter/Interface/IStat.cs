using FMRookyScouter.Item;
using System.Collections.Generic;

namespace FMRookyScouter.Interface
{
    public interface IStat
    {
    }

    public static class StatExt
    {
        public static IEnumerable<StatUnitItem> GetItems(this IStat stat)
        {
            var properties = stat.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(stat);
                if (!(value is int intValue))
                    continue;

                yield return new StatUnitItem()
                {
                    Name = property.Name,
                    Value = intValue,
                };
            }
        }
    }
}
