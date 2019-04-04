<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/MapControl_SearchPanel/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MapControl_SearchPanel/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/MapControl_SearchPanel/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MapControl_SearchPanel/MainWindow.xaml.vb))
<!-- default file list end -->
# How to manually process search using a custom search panel


This example demonstrates how to create a custom search panel and manually process data obtained from the search request.


<h3>Description</h3>

<p>To implement custom search, call the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapBingSearchDataProvider_Searchtopic">BingSearchDataProvider.Search</a> method. In this example a custom search panel contains two text edits (for the <strong>Keyword</strong> and <strong>Location</strong>) and the <strong>Search</strong> button.<br />The <strong>Search </strong>button's click event handler includes&nbsp;the call of the <strong>Search</strong> method and&nbsp;the <strong>Keyword</strong> and <strong>Location</strong> Edits text values are sent as its parameters.<br /><br />To manually process the&nbsp;result of the search request, handle the&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapBingSearchDataProvidertopic">BingSearchDataProvider.SearchCompleted</a> event.</p>

<br/>


