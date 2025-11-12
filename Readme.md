<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128571708/25.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T189413)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Map for WPF - How to Manually Process Search with a Custom Search Panel

This example demonstrates how to create a custom search panel and manually process data obtained from the search request.

## Example Overview

To implement custom search, call the [AzureSearchDataProvider.Search](https://docs.devexpress.com/WPF/DevExpress.Xpf.Map.AzureSearchDataProvider.Search.overloads) method. In this example a custom search panel contains two text edits (for the **Keyword** and **Location**) and the **Search** button.

The **Search** button's click event handler includes the call of the **Search** method and the **Keyword** and **Location** Edits text values are sent as its parameters.

To manually process the result of the search request, handle the [AzureSearchDataProvider.SearchCompleted](https://docs.devexpress.com/WPF/DevExpress.Xpf.Map.AzureSearchDataProvider.SearchCompleted) event.

## Files to Review 

* [MainWindow.xaml](./CS/MapControl_SearchPanel/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MapControl_SearchPanel/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MapControl_SearchPanel/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MapControl_SearchPanel/MainWindow.xaml.vb))

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-map-process-search-with-a-custom-search-panel&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-map-process-search-with-a-custom-search-panel&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
