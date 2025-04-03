namespace EFormBuilder.Models
{
    public class FormTemplate
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Untitled Form";
        public string Description { get; set; } = "";
        public List<FormElement> Elements { get; set; } = new List<FormElement>();
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string Department { get; set; }
        public List<string> AllowedDepartments { get; set; } = new List<string>();
    }

    public class FormElement
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; }
        public string Label { get; set; } = "";
        public string Placeholder { get; set; } = "";
        public bool Required { get; set; } = false;
        public List<FormElementOption> Options { get; set; } = new List<FormElementOption>();
        public string DefaultValue { get; set; } = "";
        public bool ReadOnly { get; set; } = false;
        public int Order { get; set; }
        public string HelpText { get; set; } = "";
        public Dictionary<string, string> ValidationRules { get; set; } = new Dictionary<string, string>();
    }

    public class FormElementOption
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class FormSubmission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FormTemplateId { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public Dictionary<string, string> FormData { get; set; } = new Dictionary<string, string>();
        public SubmissionStatus Status { get; set; } = SubmissionStatus.Submitted;
        public List<FormApproval> Approvals { get; set; } = new List<FormApproval>();
    }

    public class FormApproval
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FormSubmissionId { get; set; }
        public string ApproverId { get; set; }
        public string ApproverName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
        public string Comments { get; set; } = "";
        public int Order { get; set; }
    }

    public enum SubmissionStatus
    {
        Draft,
        Submitted,
        InReview,
        Approved,
        Rejected,
        Cancelled
    }

    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}