using System;
using System.Threading.Tasks;
using Moq;
using Witsml;
using WitsmlExplorer.Api.Jobs;
using WitsmlExplorer.Api.Jobs.Common;
using WitsmlExplorer.Api.Services;
using WitsmlExplorer.Api.Workers;
using Xunit;

namespace WitsmlExplorer.Api.Tests.Workers
{
    public class RenameMnemonicWorkerTests
    {
        private readonly RenameMnemonicWorker worker;
        private const string WellUid = "wellUid";
        private const string WellboreUid = "wellboreUid";
        private const string LogUid = "logUid";

        public RenameMnemonicWorkerTests()
        {
            var witsmlClient = new Mock<IWitsmlClient>();
            var witsmlClientProvider = new Mock<IWitsmlClientProvider>();
            witsmlClientProvider.Setup(provider => provider.GetClient()).Returns(witsmlClient.Object);
            worker = new RenameMnemonicWorker(witsmlClientProvider.Object);
        }

        [Fact]
        public async void MnemonicEmpty_RenameMnemonic_ShouldThrowException()
        {
            var job = CreateJobTemplate() with
            {
                Mnemonic = "",
                NewMnemonic = "Felgen"
            };

            Task ExecuteWorker() => worker.Execute(job);

            await Assert.ThrowsAsync<InvalidOperationException>(ExecuteWorker);
        }

        [Fact]
        public async void NewMnemonicNull_RenameMnemonic_ShouldThrowException()
        {
            var job = CreateJobTemplate() with
            {
                Mnemonic = "Reodor",
                NewMnemonic = null
            };

            Task ExecuteWorker() => worker.Execute(job);

            await Assert.ThrowsAsync<InvalidOperationException>(ExecuteWorker);
        }

        private static RenameMnemonicJob CreateJobTemplate()
        {
            return new RenameMnemonicJob
            {
                LogReference = new LogReference
                {
                    WellUid = WellUid,
                    WellboreUid = WellboreUid,
                    LogUid = LogUid
                }
            };
        }
    }
}
