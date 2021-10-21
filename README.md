# How to serialize the filtered values based on FilterMode of the column in WPF and UWP DataGrid (SfDataGrid)?

This example illustrates how to serialize the filtered values based on FilterMode of the column in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid).

The filtered values from both [FilterMode](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.FilterMode.html) will be serialized by default [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid). If you want to serialize the filtered values based on either AdvancedFilter mode or CheckBoxFilter mode, write custom [SerializationController](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.SerializationController.html) and overriding the [StoreFilterPredicates](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.SerializationController~StoreFilterPredicates.html) method, where you need to store the filter values based on the [Column.FilteredFrom](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridColumn~FilteredFrom.html) property.

KB article - [How to serialize the filtered values based on FilterMode of the column in WPF and UWP DataGrid (SfDataGrid)?](https://www.syncfusion.com/kb/9900/how-to-serialize-the-filtered-values-based-on-filter-mode-of-the-column-in-wpf-datagrid)
