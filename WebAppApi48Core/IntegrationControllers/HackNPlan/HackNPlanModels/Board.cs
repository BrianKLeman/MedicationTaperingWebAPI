using Newtonsoft.Json;

namespace WebAppApi48Core.IntegrationControllers.HackNPlan.HackNPlanModels
{

    public class Creator
    {
        public int Id { get; set; }

        
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }
    }

    public class Board
    {
        public int ProjectId { get; set; }
        public int BoardId { get; set; }
        public string? MilestoneId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? GeneralInfo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Creator? Creator { get; set; }
        public bool IsDefault { get; set; }
    }

    public class HackNPlanProject
    {
        [JsonProperty("Id")]
        public uint Id { get; set; }

        [JsonProperty("WorkspaceId")]
        public int WorkspaceId { get; set; }

        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Description")]
        public string? Description { get; set; }

        [JsonProperty("GeneralInfo")]
        public string? GeneralInfo { get; set; }

        [JsonProperty("ClosingDate")]
        public DateTime? ClosingDate { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("Owner")]
        public Creator? Owner { get; set; }

        [JsonProperty("CostMetric")]
        public string? CostMetric { get; set; }

        [JsonProperty("IsDemo")]
        public bool IsDemo { get; set; }

        [JsonProperty("HoursPerDay")]
        public int HoursPerDay { get; set; }

        [JsonProperty("ModuleConfig")]
        public object? ModuleConfig { get; set; }

        [JsonProperty("DefaultBoardId")]
        public int DefaultBoardId { get; set; }
    }



    public class Category
    {
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Icon")]
        public object? Icon { get; set; }

        [JsonProperty("Color")]
        public object? Color { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime? CreationDate { get; set; }
    }

    public class ImportanceLevel
    {
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("ImportanceLevelId")]
        public int ImportanceLevelId { get; set; }

        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Icon")]
        public object? Icon { get; set; }

        [JsonProperty("Color")]
        public object? Color { get; set; }

        [JsonProperty("IsDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime CreationDate { get; set; }
    }

    public class WorkItem
    {
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("WorkItemId")]
        public uint WorkItemId { get; set; }

        [JsonProperty("ParentStoryId")]
        public int? ParentStoryId { get; set; }

        [JsonProperty("IsStory")]
        public bool IsStory { get; set; }

        [JsonProperty("Title")]
        public string? Title { get; set; }

        [JsonProperty("Description")]
        public string? Description { get; set; }

        [JsonProperty("Category")]
        public Category? Category { get; set; }

        [JsonProperty("Stage")]
        public Stage? Stage { get; set; }

        [JsonProperty("EstimatedCost")]
        public decimal? EstimatedCost { get; set; }

        [JsonProperty("LoggedCost")]
        public decimal? LoggedCost { get; set; }

        [JsonProperty("StoryTasksEstimatedCost")]
        public decimal? StoryTasksEstimatedCost { get; set; }

        [JsonProperty("StoryTasksLoggedCost")]
        public decimal? StoryTasksLoggedCost { get; set; }

        [JsonProperty("BoardIndex")]
        public int? BoardIndex { get; set; }

        [JsonProperty("DesignElementIndex")]
        public int DesignElementIndex { get; set; }

        [JsonProperty("DesignElement")]
        public object? DesignElement { get; set; }

        [JsonProperty("StartDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("DueDate")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [JsonProperty("ClosingDate")]
        public DateTime? ClosingDate { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("User")]
        public Creator? User { get; set; }

        [JsonProperty("Board")]
        public Board? Board { get; set; }

        [JsonProperty("AssignedUsers")]
        public List<object> AssignedUsers { get; set; }

        [JsonProperty("Tags")]
        public List<object> Tags { get; set; }

        [JsonProperty("ImportanceLevel")]
        public ImportanceLevel? ImportanceLevel { get; set; }

        [JsonProperty("Picture")]
        public object? Picture { get; set; }

        [JsonProperty("HasDependencies")]
        public bool HasDependencies { get; set; }

        [JsonProperty("IsBlocked")]
        public bool IsBlocked { get; set; }
    }

    public class Stage
    {
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("StageId")]
        public int StageId { get; set; }

        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Icon")]
        public object? Icon { get; set; }

        [JsonProperty("Color")]
        public object? Color { get; set; }

        [JsonProperty("Status")]
        public string? Status { get; set; }

        [JsonProperty("IsUnblocker")]
        public bool IsUnblocker { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime? CreationDate { get; set; }
    }


}
