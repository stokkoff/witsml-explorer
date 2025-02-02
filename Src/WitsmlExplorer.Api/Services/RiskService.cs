using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitsmlExplorer.Api.Query;
using Witsml.ServiceReference;
using WitsmlExplorer.Api.Models;

namespace WitsmlExplorer.Api.Services
{
    public interface IRiskService
    {
        Task<IEnumerable<Risk>> GetRisks(string wellUid, string wellboreUid);

    }

    // ReSharper disable once UnusedMember.Global
    public class RiskService : WitsmlService, IRiskService
    {
        public RiskService(IWitsmlClientProvider witsmlClientProvider) : base(witsmlClientProvider) { }

        public async Task<IEnumerable<Risk>> GetRisks(string wellUid, string wellboreUid)
        {
            var query = RiskQueries.GetWitsmlRiskByWellbore(wellUid, wellboreUid);
            var result = await WitsmlClient.GetFromStoreAsync(query, new OptionsIn(ReturnElements.All));


            return result.Risks.Select(risk =>
                new Risk
                {
                    Name = risk.Name,
                    NameWellbore = risk.NameWellbore,
                    UidWellbore = risk.UidWellbore,
                    NameWell = risk.NameWell,
                    UidWell = risk.UidWell,
                    Uid = risk.Uid,
                    Type = risk.Type,
                    Category = risk.Category,
                    SubCategory = risk.SubCategory,
                    ExtendCategory = risk.ExtendCategory,
                    AffectedPersonnel = (risk.AffectedPersonnel != null) ? string.Join(", ", risk.AffectedPersonnel) : "",
                    DTimStart = StringHelpers.ToDateTime(risk.DTimStart),
                    DTimEnd = StringHelpers.ToDateTime(risk.DTimEnd),
                    DTimCreation = StringHelpers.ToDateTime(risk.CommonData.DTimCreation),
                    DTimLastChange = StringHelpers.ToDateTime(risk.CommonData.DTimLastChange),
                    MdBitStart = risk.MdBitStart?.Value,
                    MdBitEnd = risk.MdBitEnd?.Value,
                    SourceName = risk.CommonData.SourceName,
                    SeverityLevel = risk.SeverityLevel,
                    ProbabilityLevel = risk.ProbabilityLevel,
                }).OrderBy(risk => risk.Name);
        }
    }
}
