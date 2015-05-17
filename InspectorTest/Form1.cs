using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InspectorTest
{
    public partial class Form1 : Form
    {
        public Form1(InspectorService inspector)
        {
            InitializeComponent();

            Observable.FromEventPattern(RefreshButton, "Click")
                .Subscribe(_ => inspector.RequestInspection());

            inspector.InspectionRequests
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(_ =>
                {
                    RefreshButton.Enabled = false;
                    ProgressBar.Visible = true;
                });

            inspector.InspectionResults
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(results =>
                {
                    RefreshButton.Enabled = true;
                    ProgressBar.Visible = false;
                    Results.Text = results;
                });

            new Form2(inspector).Show();
        }
    }
}
