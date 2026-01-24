using DataAccessLayer.Models;
using System.Security.Cryptography.X509Certificates;

namespace WebAppApi48Core.IntegrationControllers.HackNPlan
{
    public static class HackNPlanConverterExtensions
    {
        public static Sprint ToNewSprint(this HackNPlanModels.Board board, uint personCode)
        {
            return ToSprint(board, personCode, 0);
        }
        public static Sprint ToSprint(this HackNPlanModels.Board board, uint personCode, uint id)
        {
            return new Sprint
            {
                Id = id,
                Name = board.Name,
                Description = board.Description,
                StartDate = board.StartDate,
                EndDate = board.DueDate,
                PersonId = personCode,
                CreatedDate = board.CreationDate,
                BoardId = (uint)board.BoardId,
                ClosedDate = board.ClosingDate
            };
        }

        public static Projects ToProject(this HackNPlanModels.HackNPlanProject project, uint personCode, uint id)
        {
            return new Projects
            {
                Id = id,
                Name = project.Name,
                PersonId = personCode,
                CreatedDate = project.CreationDate ?? DateTime.UtcNow,
                ExtProjectID = project.Id
            };
        }

        public static Tasks ToNewTask(this HackNPlanModels.WorkItem workItem, uint personCode)
        {
            return ToTask(workItem, personCode, 0);
        }

        public static Tasks ToTask(this HackNPlanModels.WorkItem workItem, uint personCode, uint id)
        {
            return new Tasks
            {
                Id = id,
                TaskName = workItem.Title,
                Description = workItem.Description,
                PersonId = personCode,
                CreatedDate = workItem.CreationDate,                
                ExternalID = workItem.WorkItemId,
                Status = workItem.ToTaskStatus(),
                DueDate = workItem.DueDate,
                DateCompleted = workItem.ClosingDate,
                Estimate = (int)(workItem.EstimatedCost ?? 0),
                Priority = workItem.ToTaskPriority()
            };
        }

        public static string ToTaskStatus(this HackNPlanModels.WorkItem workItem)
        {
            switch (workItem.Stage.StageId)
            {
                case 1:
                    return "NOT_STARTED";
                case 2:
                    return "IN_PROGRESS";
                case 3:
                    return "IN_REVIEW";
                case 4:
                    return "COMPLETED";
                default:
                    throw new Exception("Unknown Stage Type: Unable to convert.");
            }
        }

        public static int ToTaskPriority(this HackNPlanModels.WorkItem workItem)
        {
            return workItem.ImportanceLevel.ImportanceLevelId;
        }
    }
}
