using Suls.Data;
using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public interface ISubmissionService
    {
        Problem GetProblemById(string id);

        void CreateSubmission(string ProblemId, string code, string userId, ushort achievedResult);
    }
}
