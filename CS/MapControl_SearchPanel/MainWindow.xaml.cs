using DevExpress.Xpf.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MapControl_SearchPanel {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        #region #CustomSearch
        private void bSearch_Click(object sender, RoutedEventArgs e) {
            tbSearchResult.Text = "";
            searchProvider.Search(tbLocation.Text);
        }
        #endregion #CustomSearch

        private void ValidationError(object sender, ValidationErrorEventArgs e) {
            if (e.Action == ValidationErrorEventAction.Added)
                MessageBox.Show(e.Error.ErrorContent.ToString());
        }
        #region #SearchCompletedEventHandler
        private void searchProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e) {
            if (e.Cancelled) return;
            if (e.RequestResult.ResultCode != RequestResultCode.Success) return;

            StringBuilder sb = new StringBuilder();

            SearchRequestResult requestResult = e.RequestResult;
            sb.Append(String.Format("Result Code: {0}\n", requestResult.ResultCode));
            if (String.IsNullOrEmpty(requestResult.FaultReason))
                sb.Append(String.Format("Fault Reason: (none)\n", requestResult.FaultReason));
            else
                sb.Append(String.Format("Fault Reason: {0}\n", requestResult.FaultReason));
            sb.Append(String.Format("Search Location: {0}\n", requestResult.Keyword));
            sb.Append(String.Format("Estimated Matches: {0}\n", requestResult.EstimatedMatches));
            sb.Append(String.Format("SearchResults:\n{0}", ProcessLocationList(requestResult.SearchResults)));

            tbSearchResult.Text = sb.ToString();

        }

        string ProcessLocationList(List<LocationInformation> results) {
            if (results == null) return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < results.Count; i++) {
                sb.Append(String.Format("{0}) {1}", i + 1, ProcessLocationInformation(results[i])));
            }
            return sb.ToString();
        }
        #endregion #SearchCompletedEventHandler

        #region #ProcessLocationInformation
        string ProcessLocationInformation(LocationInformation info) {
            if (info == null) return "";

            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("{0}\n", info.DisplayName));
            sb.Append(String.Format("\tAdress: {0}\n", info.Address));
            sb.Append(String.Format("\tLocation: {0}\n", info.Location));
            return sb.ToString();
        }
        #endregion #ProcessLocationInformation
    }

    class NonNegativeIntValidationRule : ValidationRule {
        int min = 0;
        int max = int.MaxValue;

        public int Min { get { return min; } }
        public int Max {
            get {
                return max;
            }
            set {
                if (value != max)
                    max = value;
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            int i;
            if (!int.TryParse(value as string, NumberStyles.Integer ,cultureInfo, out i))
                return new ValidationResult(false, "Input value should be an integer.");
            if ((i > max) || (i < min))
                return new ValidationResult(
                    false,
                    string.Format("Input value should be larger than or equals to 0 and les than or equals to {0}", max)
                );
            return new ValidationResult(true, null);
        }
    }
}
