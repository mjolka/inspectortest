using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace InspectorTest
{
    public class InspectorService
    {
        private readonly Subject<Unit> _inspectionRequests = new Subject<Unit>();

        public InspectorService(Inspector inspector)
        {
            var inspectionResults = _inspectionRequests
                .ObserveOn(Scheduler.Default)
                .Select(_ => inspector.GetInspectionResults())
                .Publish();
            inspectionResults.Connect();
            InspectionResults = inspectionResults;
        }

        public void RequestInspection()
        {
            _inspectionRequests.OnNext(Unit.Default);
        }

        public IObservable<Unit> InspectionRequests
        {
            get { return _inspectionRequests; }
        }

        public IObservable<string> InspectionResults { get; }
    }
}
