using System.Text.Json.Serialization;

namespace EFormBuilder.Models
{
    public class UserResponse
    {
        [JsonPropertyName("System_Prefix_EN")]
        public PrefixEN SystemPrefixEN { get; set; }

        [JsonPropertyName("System_Prefix_TH")]
        public PrefixTH SystemPrefixTH { get; set; }

        [JsonPropertyName("Users")]
        public User Users { get; set; }

        [JsonPropertyName("Detail_EN_FirstName")]
        public string DetailENFirstName { get; set; }

        [JsonPropertyName("Detail_EN_LastName")]
        public string DetailENLastName { get; set; }

        [JsonPropertyName("Detail_TH_FirstName")]
        public string DetailTHFirstName { get; set; }

        [JsonPropertyName("Detail_TH_LastName")]
        public string DetailTHLastName { get; set; }

        [JsonPropertyName("Prefix_EN_Id")]
        public int PrefixENId { get; set; }

        [JsonPropertyName("Prefix_TH_Id")]
        public int PrefixTHId { get; set; }

        [JsonPropertyName("User_Id")]
        public string UserId { get; set; }
    }

    public class PrefixEN
    {
        [JsonPropertyName("Prefix_EN_Id")]
        public int PrefixENId { get; set; }

        [JsonPropertyName("Prefix_EN_Name")]
        public string PrefixENName { get; set; }
    }

    public class PrefixTH
    {
        [JsonPropertyName("Prefix_TH_Id")]
        public int PrefixTHId { get; set; }

        [JsonPropertyName("Prefix_TH_Name")]
        public string PrefixTHName { get; set; }
    }

    public class User
    {
        [JsonPropertyName("Master_Grades")]
        public MasterGrades MasterGrades { get; set; }

        [JsonPropertyName("Master_Plants")]
        public MasterPlants MasterPlants { get; set; }

        [JsonPropertyName("Master_Processes")]
        public MasterProcesses MasterProcesses { get; set; }

        [JsonPropertyName("System_Roles")]
        public SystemRoles SystemRoles { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("BusinessCardGroup")]
        public bool BusinessCardGroup { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Grade_Id")]
        public string GradeId { get; set; }

        [JsonPropertyName("Plant_Id")]
        public string PlantId { get; set; }

        [JsonPropertyName("Process_Id")]
        public string ProcessId { get; set; }

        [JsonPropertyName("Role_Id")]
        public int RoleId { get; set; }

        [JsonPropertyName("Update")]
        public DateTime Update { get; set; }

        [JsonPropertyName("User_Code")]
        public string UserCode { get; set; }

        [JsonPropertyName("User_CostCenter")]
        public string UserCostCenter { get; set; }

        [JsonPropertyName("User_Email")]
        public string UserEmail { get; set; }

        [JsonPropertyName("User_Id")]
        public string UserId { get; set; }

        [JsonPropertyName("User_Point")]
        public int UserPoint { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("YearSetPoint")]
        public int YearSetPoint { get; set; }
    }

    public class MasterGrades
    {
        [JsonPropertyName("Master_LineWorks")]
        public MasterLineWorks MasterLineWorks { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Grade_Id")]
        public string GradeId { get; set; }

        [JsonPropertyName("Grade_Name")]
        public string GradeName { get; set; }

        [JsonPropertyName("Grade_Position")]
        public string GradePosition { get; set; }

        [JsonPropertyName("LineWork_Id")]
        public string LineWorkId { get; set; }

        [JsonPropertyName("Update")]
        public object Update { get; set; }
    }

    public class MasterLineWorks
    {
        [JsonPropertyName("System_Authorize")]
        public SystemAuthorize SystemAuthorize { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Authorize_Id")]
        public int AuthorizeId { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("LineWork_Id")]
        public string LineWorkId { get; set; }

        [JsonPropertyName("LineWork_Name")]
        public string LineWorkName { get; set; }

        [JsonPropertyName("Update")]
        public DateTime Update { get; set; }
    }

    public class SystemAuthorize
    {
        [JsonPropertyName("Authorize_Id")]
        public int AuthorizeId { get; set; }

        [JsonPropertyName("Authorize_Name")]
        public string AuthorizeName { get; set; }
    }

    public class MasterPlants
    {
        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Plant_Id")]
        public string PlantId { get; set; }

        [JsonPropertyName("Plant_Name")]
        public string PlantName { get; set; }

        [JsonPropertyName("Update")]
        public DateTime Update { get; set; }
    }

    public class MasterProcesses
    {
        [JsonPropertyName("Master_Sections")]
        public MasterSections MasterSections { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Process_Id")]
        public string ProcessId { get; set; }

        [JsonPropertyName("Process_Name")]
        public string ProcessName { get; set; }

        [JsonPropertyName("Section_Id")]
        public string SectionId { get; set; }

        [JsonPropertyName("Update")]
        public object Update { get; set; }
    }

    public class MasterSections
    {
        [JsonPropertyName("Master_Departments")]
        public MasterDepartments MasterDepartments { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Department_Id")]
        public string DepartmentId { get; set; }

        [JsonPropertyName("Section_Id")]
        public string SectionId { get; set; }

        [JsonPropertyName("Section_Name")]
        public string SectionName { get; set; }

        [JsonPropertyName("Update")]
        public object Update { get; set; }
    }

    public class MasterDepartments
    {
        [JsonPropertyName("Master_Divisions")]
        public MasterDivisions MasterDivisions { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Department_Id")]
        public string DepartmentId { get; set; }

        [JsonPropertyName("Department_Name")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("Division_Id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("Update")]
        public object Update { get; set; }
    }

    public class MasterDivisions
    {
        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("Create")]
        public DateTime Create { get; set; }

        [JsonPropertyName("Division_Id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("Division_Name")]
        public string DivisionName { get; set; }

        [JsonPropertyName("Update")]
        public object Update { get; set; }
    }

    public class SystemRoles
    {
        [JsonPropertyName("Role_Id")]
        public int RoleId { get; set; }

        [JsonPropertyName("Role_Name")]
        public string RoleName { get; set; }
    }
}