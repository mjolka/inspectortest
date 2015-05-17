using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InspectorTest
{
    public partial class Form2 : Form
    {
        public Form2(InspectorService inspector)
        {
            InitializeComponent();

            Observable.FromEventPattern(RefreshButton, "Click")
                .Subscribe(_ => inspector.RequestInspection());

            inspector.InspectionRequests
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(_ => RefreshButton.Enabled = false);

            inspector.InspectionResults
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(results =>
                {
                    RefreshButton.Enabled = true;
                    Results.Text = results;
                });
        }
    }
}
