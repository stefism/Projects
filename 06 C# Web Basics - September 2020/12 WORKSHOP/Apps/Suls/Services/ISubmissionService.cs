using Suls.Data;
using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public interface ISubmissionService
    {
        Problem GetProblemById(string id);

        void CreateSubmission(string ProblemId, string code, string userId, ushort achievedResult); // Me

        void DeleteSubmissions(string id);

        void Create(string problemId, string userId, string code); //Lector
    }
}
