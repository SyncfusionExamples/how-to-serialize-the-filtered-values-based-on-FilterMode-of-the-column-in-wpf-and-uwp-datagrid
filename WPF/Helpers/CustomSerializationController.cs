using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public class CustomSerializationController : SerializationController
    {
        public CustomSerializationController(SfDataGrid dataGrid) : base(dataGrid)
        {

        }
        protected override SerializableFilterSettings StoreFilterPredicates(SfDataGrid dataGrid, SerializationOptions serializeOptions)
        {
            SerializableFilterSettings filterSettings = new SerializableFilterSettings();
            if (!serializeOptions.SerializeFiltering)
                return filterSettings;

            foreach (var column in dataGrid.Columns.Where(c => c.FilterPredicates.Count > 0 && c.FilteredFrom== FilteredFrom.AdvancedFilter))
            {
                SerializableFilterSetting filterSetting = new SerializableFilterSetting() { ColumnName = column.MappingName, Filter = new ObservableCollection<SerializableFilter>() };
                foreach (var filterPredicate in column.FilterPredicates)
                {
                    SerializableFilter filter = new SerializableFilter() { FilterBehavior = filterPredicate.FilterBehavior, FilterType = filterPredicate.FilterType, FilterValue = filterPredicate.FilterValue, IsCaseSensitive = filterPredicate.IsCaseSensitive, PredicateType = filterPredicate.PredicateType };
                    filterSetting.Filter.Add(filter);
                }
                filterSettings.Add(filterSetting);
            }
            return filterSettings;
        }
    }
}
