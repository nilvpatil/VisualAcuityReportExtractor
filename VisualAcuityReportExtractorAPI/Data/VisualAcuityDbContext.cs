using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VisualAcuityReportExtractorAPI.Models;

namespace VisualAcuityReportExtractorAPI.Data
{
    public class VisualAcuityDbContext : DbContext
    {
        public VisualAcuityDbContext(DbContextOptions<VisualAcuityDbContext> options) : base(options)
        {

        }

        public DbSet<VisualTestResult> VisionTestResults { get; set; }
    }
}
