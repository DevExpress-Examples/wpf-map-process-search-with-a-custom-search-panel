<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128571708/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T189413)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Map for WPF - How to Manually Process Search with a Custom Search Panel

This example demonstrates how to create a custom search panel and manually process data obtained from the search request.

## Example Overview

<p>To implement custom search, call the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapBingSearchDataProvider_Searchtopic">BingSearchDataProvider.Search</a> method. In this example a custom search panel contains two text edits (for the <strong>Keyword</strong> and <strong>Location</strong>) and the <strong>Search</strong> button.<br />The <strong>Search </strong>button's click event handler includes&nbsp;the call of the <strong>Search</strong> method and&nbsp;the <strong>Keyword</strong> and <strong>Location</strong> Edits text values are sent as its parameters.<br /><br />To manually process the&nbsp;result of the search request, handle the&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapBingSearchDataProvidertopic">BingSearchDataProvider.SearchCompleted</a> event.</p>

## Files to Review 

* [MainWindow.xaml](./CS/MapControl_SearchPanel/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MapControl_SearchPanel/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MapControl_SearchPanel/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MapControl_SearchPanel/MainWindow.xaml.vb))

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-map-process-search-with-a-custom-search-panel&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-map-process-search-with-a-custom-search-panel&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
