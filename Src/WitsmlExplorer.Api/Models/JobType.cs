namespace WitsmlExplorer.Api.Models
{
    public enum JobType
    {
        CopyLog = 1,
        CopyLogData,
        CopyTrajectory,
        CopyTubular,
        CopyTubularComponents,
        TrimLogObject,
        ModifyLogObject,
        DeleteMessageObjects,
        ModifyMessageObject,
        DeleteCurveValues,
        DeleteLogObjects,
        DeleteMnemonics,
        DeleteTrajectory,
        DeleteTubular,
        DeleteTubularComponents,
        DeleteWell,
        DeleteWellbore,
        DeleteRisk,
        DeleteMudLog,
        RenameMnemonic,
        ModifyTubular,
        ModifyTubularComponent,
        ModifyWell,
        ModifyWellbore,
        ModifyMudLog,
        CreateLogObject,
        CreateWell,
        CreateWellbore,
        CreateRisk,
        CreateMudLog,
        BatchModifyWell,
        ImportLogData
    }
}
