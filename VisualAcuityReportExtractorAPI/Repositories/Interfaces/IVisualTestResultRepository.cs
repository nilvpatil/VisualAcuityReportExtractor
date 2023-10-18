using VisualAcuityReportExtractorAPI.Models;

namespace VisualAcuityReportExtractorAPI.Repositories.Interfaces
{
    public interface IVisualTestResultRepository
    {
        Task BulkInsert(List<VisualTestResult> records);
    }
}
