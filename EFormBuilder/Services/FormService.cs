using System.Text.Json;
using EFormBuilder.Models;

namespace EFormBuilder.Services
{
    public interface IFormService
    {
        Task<List<FormTemplate>> GetFormTemplates();
        Task<FormTemplate> GetFormTemplate(string id);
        Task<bool> SaveFormTemplate(FormTemplate template);
        Task<bool> DeleteFormTemplate(string id);
        Task<List<FormSubmission>> GetFormSubmissions(string templateId = null);
        Task<FormSubmission> GetFormSubmission(string id);
        Task<bool> SaveFormSubmission(FormSubmission submission);
        Task<bool> UpdateSubmissionStatus(string id, SubmissionStatus status);
        Task<bool> AddFormApproval(FormApproval approval);
        Task<bool> UpdateFormApproval(FormApproval approval);
    }

    // This is a mock implementation that would be replaced with a real database implementation
    public class InMemoryFormService : IFormService
    {
        private List<FormTemplate> _templates = new List<FormTemplate>();
        private List<FormSubmission> _submissions = new List<FormSubmission>();
        private readonly ILogger<InMemoryFormService> _logger;

        public InMemoryFormService(ILogger<InMemoryFormService> logger)
        {
            _logger = logger;
            // Add some sample templates for testing
            _templates.Add(new FormTemplate
            {
                Id = "1",
                Title = "Employee Leave Request",
                Description = "Use this form to request time off",
                Elements = new List<FormElement>
                {
                    new FormElement
                    {
                        Id = "field1",
                        Type = "text",
                        Label = "Reason for Leave",
                        Required = true,
                        Order = 0
                    },
                    new FormElement
                    {
                        Id = "field2",
                        Type = "date",
                        Label = "Start Date",
                        Required = true,
                        Order = 1
                    },
                    new FormElement
                    {
                        Id = "field3",
                        Type = "date",
                        Label = "End Date",
                        Required = true,
                        Order = 2
                    },
                    new FormElement
                    {
                        Id = "field4",
                        Type = "select",
                        Label = "Leave Type",
                        Required = true,
                        Order = 3,
                        Options = new List<FormElementOption>
                        {
                            new FormElementOption { Value = "vacation", Label = "Vacation" },
                            new FormElementOption { Value = "sick", Label = "Sick Leave" },
                            new FormElementOption { Value = "personal", Label = "Personal Leave" }
                        }
                    }
                },
                CreatedBy = "31debf3e-dffc-4600-aecf-8f7e2ce85000",
                Department = "Information Technology"
            });
        }

        public async Task<List<FormTemplate>> GetFormTemplates()
        {
            // Simulate an async operation
            await Task.Delay(10);
            return _templates;
        }

        public async Task<FormTemplate> GetFormTemplate(string id)
        {
            await Task.Delay(10);
            return _templates.FirstOrDefault(t => t.Id == id);
        }

        public async Task<bool> SaveFormTemplate(FormTemplate template)
        {
            try
            {
                await Task.Delay(10);
                var existingTemplate = _templates.FirstOrDefault(t => t.Id == template.Id);
                
                if (existingTemplate != null)
                {
                    // Update existing template
                    var index = _templates.IndexOf(existingTemplate);
                    template.ModifiedDate = DateTime.Now;
                    _templates[index] = template;
                }
                else
                {
                    // Add new template
                    _templates.Add(template);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving form template {TemplateId}", template.Id);
                return false;
            }
        }

        public async Task<bool> DeleteFormTemplate(string id)
        {
            try
            {
                await Task.Delay(10);
                var template = _templates.FirstOrDefault(t => t.Id == id);
                
                if (template != null)
                {
                    _templates.Remove(template);
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting form template {TemplateId}", id);
                return false;
            }
        }

        public async Task<List<FormSubmission>> GetFormSubmissions(string templateId = null)
        {
            await Task.Delay(10);
            
            if (string.IsNullOrEmpty(templateId))
            {
                return _submissions;
            }
            
            return _submissions.Where(s => s.FormTemplateId == templateId).ToList();
        }

        public async Task<FormSubmission> GetFormSubmission(string id)
        {
            await Task.Delay(10);
            return _submissions.FirstOrDefault(s => s.Id == id);
        }

        public async Task<bool> SaveFormSubmission(FormSubmission submission)
        {
            try
            {
                await Task.Delay(10);
                var existingSubmission = _submissions.FirstOrDefault(s => s.Id == submission.Id);
                
                if (existingSubmission != null)
                {
                    // Update existing submission
                    var index = _submissions.IndexOf(existingSubmission);
                    _submissions[index] = submission;
                }
                else
                {
                    // Add new submission
                    _submissions.Add(submission);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving form submission {SubmissionId}", submission.Id);
                return false;
            }
        }

        public async Task<bool> UpdateSubmissionStatus(string id, SubmissionStatus status)
        {
            try
            {
                await Task.Delay(10);
                var submission = _submissions.FirstOrDefault(s => s.Id == id);
                
                if (submission != null)
                {
                    submission.Status = status;
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating submission status {SubmissionId}", id);
                return false;
            }
        }

        public async Task<bool> AddFormApproval(FormApproval approval)
        {
            try
            {
                await Task.Delay(10);
                var submission = _submissions.FirstOrDefault(s => s.Id == approval.FormSubmissionId);
                
                if (submission != null)
                {
                    submission.Approvals.Add(approval);
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding form approval {ApprovalId}", approval.Id);
                return false;
            }
        }

        public async Task<bool> UpdateFormApproval(FormApproval approval)
        {
            try
            {
                await Task.Delay(10);
                var submission = _submissions.FirstOrDefault(s => s.Id == approval.FormSubmissionId);
                
                if (submission != null)
                {
                    var existingApproval = submission.Approvals.FirstOrDefault(a => a.Id == approval.Id);
                    
                    if (existingApproval != null)
                    {
                        var index = submission.Approvals.IndexOf(existingApproval);
                        submission.Approvals[index] = approval;
                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating form approval {ApprovalId}", approval.Id);
                return false;
            }
        }
    }
}